using S100FC.Catalogues;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace S100Framework.GML
{
    public class Dataset
    {
        private static readonly Regex _substitute = new(@"^S(?<number>\d+)$", RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

        private readonly XDocument _document;

        private readonly XmlNamespaceManager _namespaceManager;
        private readonly string _namespace;
        private readonly string _prefix;
        private string PrefixHyphen => this._prefix.Replace("S", "S-");

        private readonly IDictionary<string, string> _namespaces;

        private readonly FeatureCatalogue _featureCatalogue;

        public FeatureCatalogue FeatureCatalogue => this._featureCatalogue;

        public string ProductSpecification => this._featureCatalogue.ProductID;

        public sealed class InformationType
        {
            private readonly XElement _element;
            private readonly FeatureCatalogue _featureCatalogue;

            public XElement XElement => new(this._element);

            public InformationType(XElement Member, FeatureCatalogue catalogue) {
                this._element = Member;
                this._featureCatalogue = catalogue;
            }

            public string Identifier => this._element.Attribute(XName.Get("id", this._element.GetNamespaceOfPrefix("gml")!.NamespaceName))!.Value;

            public object Value {
                get {
                    var type = this._featureCatalogue.Assembly!.GetType($"{this._featureCatalogue.DefaultNamespace}.InformationTypes.{this._element.Name.LocalName}")!;

                    var deserialized = GML.Converter.Deserialize(this._element, type);

                    return deserialized;
                }
            }
        }

        public sealed class FeatureType
        {
            private readonly XElement _element;
            private readonly FeatureCatalogue _featureCatalogue;
            private readonly XNamespace _namespace;

            public XElement XElement => new(this._element);

            public FeatureType(XElement member, FeatureCatalogue catalogue) {
                this._element = member;
                this._featureCatalogue = catalogue;

                var prefix = this._element.GetPrefixOfNamespace(this._element.Name.NamespaceName)!;
                this._namespace = this._element.GetNamespaceOfPrefix(prefix)!;
            }

            public string Identifier => this._element.Attribute(XName.Get("id", this._element.GetNamespaceOfPrefix("gml")!.NamespaceName))!.Value;
            public string? GeometryIdentifier;
            public string? GeometryType => this.Geometry?.Elements().FirstOrDefault()?.Name.LocalName.ToLower();  // e.g. pointproperty, curveproperty, surfaceproperty
            public object Value {
                get {
                    var type = this._featureCatalogue.Assembly!.GetType($"{this._featureCatalogue.DefaultNamespace}.FeatureTypes.{this._element.Name.LocalName}")!;

                    var deserialized = GML.Converter.Deserialize(this._element, type);

                    return deserialized;
                }
            }

            public XElement? Geometry => this._element.Elements().FirstOrDefault(e => e.Name.LocalName == "geometry");
        }

        public static Dataset Load(string uri) {
            return new Dataset(XDocument.Load(uri));
        }

        public static Dataset Parse(string gml) {
            return new Dataset(XDocument.Parse(gml));
        }

        protected Dataset(XDocument document) {
            this._document = document;

            var navigator = document.LastNode!.CreateNavigator();
            this._namespaces = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            this._namespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in this._namespaces)
                this._namespaceManager.AddNamespace(e.Key, e.Value);

            this._prefix = navigator.Prefix;
            this._namespace = navigator.GetNamespace(this._prefix);

            var prefix = _substitute.Replace(navigator.Prefix, @"S-${number}");


            if (!_substitute.IsMatch(prefix)) {
                var match = Regex.Match(navigator.NamespaceURI.ToString(), @"S-?(\d{3})");

                if (match.Success) {
                    var digits = match.Groups[1].Value; // "124"
                    prefix = $"S-{digits}";
                }
            }

            this._featureCatalogue = FeatureCatalogue.Catalogues.SingleOrDefault(e => e.ProductID.Equals(prefix, StringComparison.OrdinalIgnoreCase))!;
        }

        public IEnumerable<object> Members() {
            var expression = $"//{this._prefix}:*";                            // e.g S127
            var members = this._document.XPathSelectElements(expression, this._namespaceManager);

            // If members only consist of the root, try with hyphenated prefix. e.g. S-127  
            if (members?.Count() == 1)
                members = this._document.XPathSelectElements($"//{this.PrefixHyphen}:*", this._namespaceManager);

            if (members is null)
                yield break;

            foreach (var member in members) {
                var name = member.Name.LocalName;

                if (this._featureCatalogue.InformationTypes.Any(e => e.Code.Equals(name))) {
                    var instance = new InformationType(member, this._featureCatalogue);
                    yield return instance;
                }
                if (this._featureCatalogue.FeatureTypes.Any(e => e.Code.Equals(name))) {
                    var instance = new FeatureType(member, this._featureCatalogue);
                    yield return instance;
                }
            }
            yield break;
        }
    }
}
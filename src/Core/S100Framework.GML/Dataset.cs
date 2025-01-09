﻿using S100Framework.Catalogues;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Xml.XPath;

namespace S100Framework.GML
{
    public class Dataset
    {
        private static Regex _substitute = new(@"^S(?<number>\d+)$", RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

        private readonly XDocument _document;

        private readonly XmlNamespaceManager _namespaceManager;
        private readonly string _prefix;
        private readonly string _namespace;

        private readonly IDictionary<string, string> _namespaces;

        private readonly Catalogues.FeatureCatalogue _featureCatalogue;

        public Catalogues.FeatureCatalogue FeatureCatalogue => _featureCatalogue;

        public string ProductSpecification => _featureCatalogue.ProductID;

        public sealed class InformationType
        {
            private readonly XElement _element;
            private readonly FeatureCatalogue _featureCatalogue;

            public XElement XElement => new(_element);

            public InformationType(XElement Member, FeatureCatalogue catalogue) {
                _element = Member;
                _featureCatalogue = catalogue;
            }

            public string Identifier => _element.Attribute(XName.Get("id", _element.GetNamespaceOfPrefix("gml")!.NamespaceName))!.Value;

            public object Value {
                get {
                    var prefix = _element.GetPrefixOfNamespace(_element.Name.Namespace)!;

                    var type = _featureCatalogue.Assembly!.GetType($"{_featureCatalogue.DefaultNamespace}.InformationTypes.{_element.Name.LocalName}")!;
                    var serializer = new XmlSerializer(type);
                    return serializer.Deserialize(_element.CreateReader())!;
                }
            }
        }

        public sealed class FeatureType
        {
            private readonly XElement _element;
            private readonly FeatureCatalogue _featureCatalogue;
            private readonly XNamespace _namespace;

            public XElement XElement => new(_element);

            public FeatureType(XElement member, FeatureCatalogue catalogue) {
                _element = member;
                _featureCatalogue = catalogue;

                var prefix = _element.GetPrefixOfNamespace(_element.Name.NamespaceName)!;
                _namespace = _element.GetNamespaceOfPrefix(prefix)!;
            }

            public string Identifier => _element.Attribute(XName.Get("id", _element.GetNamespaceOfPrefix("gml")!.NamespaceName))!.Value;

            public object Value {
                get {
                    var prefix = _element.GetPrefixOfNamespace(_element.Name.Namespace)!;

                    var type = _featureCatalogue.Assembly!.GetType($"{_featureCatalogue.DefaultNamespace}.FeatureTypes.{_element.Name.LocalName}")!;
                    var serializer = new XmlSerializer(type);
                    return serializer.Deserialize(_element.CreateReader())!;
                }
            }

            public XElement? Geometry => _element.Element(XName.Get("geometry", _namespace.NamespaceName))!;
        }

        public static Dataset Load(string uri) {
            return new Dataset(XDocument.Load(uri));
        }

        protected Dataset(XDocument document) {
            this._document = document;

            var navigator = document.LastNode!.CreateNavigator();
            _namespaces = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            _namespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in _namespaces)
                _namespaceManager.AddNamespace(e.Key, e.Value);

            this._prefix = navigator.Prefix;
            this._namespace = navigator.GetNamespace(_prefix);

            var prefix = _substitute.Replace(navigator.Prefix, @"S-${number}");

            _featureCatalogue = Catalogues.FeatureCatalogue.Catalogues.SingleOrDefault(e => e.ProductID.Equals(prefix, StringComparison.OrdinalIgnoreCase))!;
        }

        public IEnumerable<object> Members() {
            var members = this._document.XPathSelectElement($"/{this._prefix}:Dataset/{this._prefix}:members", _namespaceManager);
            if (members is null)
                yield break;

            foreach (var member in members!.Elements()) {
                var name = member.Name.LocalName;

                if (_featureCatalogue.InformationTypes.Any(e => e.Code.Equals(name))) {
                    var instance = new InformationType(member, _featureCatalogue);
                    yield return instance;
                }
                if (_featureCatalogue.FeatureTypes.Any(e => e.Code.Equals(name))) {
                    var instance = new FeatureType(member, _featureCatalogue);
                    yield return instance;
                }
            }
            yield break;
        }
    }
}

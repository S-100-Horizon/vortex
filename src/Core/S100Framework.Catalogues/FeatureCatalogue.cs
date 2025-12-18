using S100Framework.DomainModel;
using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json;

namespace S100Framework
{
    public static class Extension
    {
        //private static Regex _substitute = new Regex(@"^S(?<number>\d+)$", RegexOptions.Singleline | RegexOptions.CultureInvariant | RegexOptions.IgnorePatternWhitespace | RegexOptions.IgnoreCase);

        //public static IEnumerable<XElement> Features(this XDocument doc) {
        //    var members = doc.XPathSelectElement("//*[local-name()='members']");
        //    if (members is null)
        //        yield break;
        //    var prefix = members.GetPrefixOfNamespace(members.Name.NamespaceName);
        //    foreach (var member in members.Elements()) {
        //        yield return member;
        //    }
        //    yield break;
        //}

        //public static string Identifier(this XElement element) {
        //    return element.Attribute(XName.Get("id", element.GetNamespaceOfPrefix("gml")!.NamespaceName))!.Value;
        //}

        //public static DomainModel.FeatureType? FeatureType(this XElement element) {
        //    var prefix = element.GetPrefixOfNamespace(element.Name.Namespace)!;

        //    var catalogue = FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals(_substitute.Replace(prefix, @"S-${number}")));

        //    var type = catalogue.Assembly!.GetType($"S100Framework.DomainModel.{prefix}.FeatureTypes.{element.Name.LocalName}")!;
        //    var serializer = new XmlSerializer(type);
        //    return serializer.Deserialize(element.CreateReader()) as DomainModel.FeatureType;
        //}
    }
}

namespace S100Framework.Catalogues
{
    public record FeatureType(string Code);

    public record InformationType(string Code);

    public record AssociationType(string Code);

    public sealed class FeatureCatalogue
    {
        public FeatureCatalogue(string productId, Version versionNumber) {
            ProductID = productId ?? throw new System.ArgumentNullException(nameof(productId));
            VersionNumber = versionNumber ?? throw new System.ArgumentNullException(nameof(versionNumber));
        }

        public string ProductID { get; private set; }

        public Version VersionNumber { get; private set; }

        public Assembly? Assembly { get; set; } = null;

        public ImmutableArray<FeatureType> FeatureTypes { get; set; } = ImmutableArray<FeatureType>.Empty;

        public ImmutableArray<AssociationType> FeatureAssociationTypes { get; set; } = ImmutableArray<AssociationType>.Empty;

        public ImmutableArray<InformationType> InformationTypes { get; set; } = ImmutableArray<InformationType>.Empty;

        public ImmutableArray<AssociationType> InformationAssociationTypes { get; set; } = ImmutableArray<AssociationType>.Empty;

        public Func<Primitives, ImmutableArray<FeatureType>> FeatureTypesByPrimivive { get; set; } = (p) => ImmutableArray<FeatureType>.Empty;

        public JsonSerializerOptions DefaultJsonOptions { get; init; }

        public string DefaultNamespace => $"S100Framework.DomainModel.{ProductID.Remove(1, 1)}";

        public static string Namespace(string ps, string types) => $"S100Framework.DomainModel.{ps.ToUpperInvariant().Replace("-", string.Empty)}.{types}";

        public static ImmutableArray<FeatureCatalogue> Catalogues => ImmutableArray.Create<FeatureCatalogue>(new FeatureCatalogue[]{
            new("S-101", DomainModel.S101.Summary.Version) {
                Assembly = typeof(DomainModel.S101.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S101.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S101.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S101.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S101.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(DomainModel.S101.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                    TypeInfoResolver = DomainModel.S101.Summary.SharedBindingResolver(),
                }
            },
            new("S-122", DomainModel.S122.Summary.Version) {
                Assembly = typeof(DomainModel.S122.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S122.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S122.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S122.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S122.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(DomainModel.S122.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                    TypeInfoResolver = DomainModel.S122.Summary.SharedBindingResolver(),
                }
            },
            new("S-123", DomainModel.S123.Summary.Version) {
                Assembly = typeof(DomainModel.S123.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S123.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S123.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S123.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S123.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(DomainModel.S123.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                    TypeInfoResolver = DomainModel.S123.Summary.SharedBindingResolver(),
                }
            },
            new("S-124", DomainModel.S124.Summary.Version) {
                Assembly = typeof(DomainModel.S124.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S124.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S124.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S124.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S124.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(DomainModel.S124.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                    TypeInfoResolver = DomainModel.S124.Summary.SharedBindingResolver(),
                }
            },
            new("S-127", DomainModel.S127.Summary.Version) {
                Assembly = typeof(DomainModel.S127.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S127.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S127.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S127.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S127.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(DomainModel.S127.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
            },
            new("S-128", DomainModel.S128.Summary.Version) {
                Assembly = typeof(DomainModel.S128.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S128.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S128.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S128.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S128.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(DomainModel.S128.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                    TypeInfoResolver = DomainModel.S128.Summary.SharedBindingResolver(),
                }
            },
            new("S-131", DomainModel.S131.Summary.Version) {
                Assembly = typeof(DomainModel.S131.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S131.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S131.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S131.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S131.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(DomainModel.S131.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                    TypeInfoResolver = DomainModel.S131.Summary.SharedBindingResolver(),
                }
            },
            new("S-201", DomainModel.S201.Summary.Version) {
                Assembly = typeof(DomainModel.S201.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S201.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S201.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S201.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(DomainModel.S201.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                    TypeInfoResolver = DomainModel.S201.Summary.SharedBindingResolver(),
                }
            },
            //new("S-501", DomainModel.S501.Summary.Version) {
            //    Assembly = typeof(DomainModel.S501.Summary).Assembly,
            //    FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S501.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
            //    FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S501.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            //    InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S501.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
            //    InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S501.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            //    FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(DomainModel.S501.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
            //    DefaultJsonOptions = new JsonSerializerOptions {
            //        Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //        PropertyNameCaseInsensitive = true,
            //        WriteIndented = false,
            //        TypeInfoResolver = DomainModel.S501.Summary.SharedBindingResolver(),
            //    }
            //},
        });
    }
}

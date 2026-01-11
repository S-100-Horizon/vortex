using S100Framework.AttributeModel;
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

        //public static AttributeModel.FeatureType? FeatureType(this XElement element) {
        //    var prefix = element.GetPrefixOfNamespace(element.Name.Namespace)!;

        //    var catalogue = FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals(_substitute.Replace(prefix, @"S-${number}")));

        //    var type = catalogue.Assembly!.GetType($"S100Framework.AttributeModel.{prefix}.FeatureTypes.{element.Name.LocalName}")!;
        //    var serializer = new XmlSerializer(type);
        //    return serializer.Deserialize(element.CreateReader()) as AttributeModel.FeatureType;
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

        //public Func<Primitives, ImmutableArray<FeatureType>> FeatureTypesByPrimivive { get; set; } = (p) => ImmutableArray<FeatureType>.Empty;

        public JsonSerializerOptions DefaultJsonOptions { get; init; } = new JsonSerializerOptions();

        public string DefaultNamespace => $"S100Framework.AttributeModel.{ProductID.Remove(1, 1)}";

        public static string Namespace(string ps, string types) => $"S100Framework.AttributeModel.{ps.ToUpperInvariant().Replace("-", string.Empty)}.{types}";

        public static ImmutableArray<FeatureCatalogue> Catalogues => ImmutableArray.Create<FeatureCatalogue>(new FeatureCatalogue[]{
            new("S-101", AttributeModel.S101.Summary.Version) {
                Assembly = typeof(AttributeModel.S101.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(AttributeModel.S101.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S101.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(AttributeModel.S101.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S101.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                //FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(AttributeModel.S101.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = AttributeModel.S101.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-122", AttributeModel.S122.Summary.Version) {
                Assembly = typeof(AttributeModel.S122.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(AttributeModel.S122.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S122.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(AttributeModel.S122.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S122.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                //FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(AttributeModel.S122.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = AttributeModel.S122.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-123", AttributeModel.S123.Summary.Version) {
                Assembly = typeof(AttributeModel.S123.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(AttributeModel.S123.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S123.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(AttributeModel.S123.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S123.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                //FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(AttributeModel.S123.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = AttributeModel.S123.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-124", AttributeModel.S124.Summary.Version) {
                Assembly = typeof(AttributeModel.S124.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(AttributeModel.S124.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S124.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(AttributeModel.S124.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S124.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                //FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(AttributeModel.S124.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = AttributeModel.S124.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-127", AttributeModel.S127.Summary.Version) {
                Assembly = typeof(AttributeModel.S127.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(AttributeModel.S127.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S127.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(AttributeModel.S127.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S127.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                //FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(AttributeModel.S127.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = AttributeModel.S127.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-128", AttributeModel.S128.Summary.Version) {
                Assembly = typeof(AttributeModel.S128.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(AttributeModel.S128.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S128.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(AttributeModel.S128.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S128.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                //FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(AttributeModel.S128.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = AttributeModel.S128.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-131", AttributeModel.S131.Summary.Version) {
                Assembly = typeof(AttributeModel.S131.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(AttributeModel.S131.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S131.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(AttributeModel.S131.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S131.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                //FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(AttributeModel.S131.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = AttributeModel.S131.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            //new("S-201", AttributeModel.S201.Summary.Version) {
            //    Assembly = typeof(AttributeModel.S201.Summary).Assembly,
            //    FeatureTypes = ImmutableArray.Create<FeatureType>(AttributeModel.S201.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
            //    InformationTypes = ImmutableArray.Create<InformationType>(AttributeModel.S201.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
            //    InformationAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S201.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            //    FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(AttributeModel.S201.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
            //    DefaultJsonOptions = new JsonSerializerOptions {
            //        Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //        PropertyNameCaseInsensitive = true,
            //        WriteIndented = false,
            //        TypeInfoResolver = AttributeModel.S201.Summary.SharedBindingResolver(),
            //    }
            //},
            //new("S-501", AttributeModel.S501.Summary.Version) {
            //    Assembly = typeof(AttributeModel.S501.Summary).Assembly,
            //    FeatureTypes = ImmutableArray.Create<FeatureType>(AttributeModel.S501.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
            //    FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S501.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            //    InformationTypes = ImmutableArray.Create<InformationType>(AttributeModel.S501.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
            //    InformationAssociationTypes = ImmutableArray.Create<AssociationType>(AttributeModel.S501.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            //    FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(AttributeModel.S501.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
            //    DefaultJsonOptions = new JsonSerializerOptions {
            //        Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //        PropertyNameCaseInsensitive = true,
            //        WriteIndented = false,
            //        TypeInfoResolver = AttributeModel.S501.Summary.SharedBindingResolver(),
            //    }
            //},
        });
    }
}

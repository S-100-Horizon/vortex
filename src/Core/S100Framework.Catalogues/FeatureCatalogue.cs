using System.Collections.Immutable;
using System.Reflection;
using System.Text.Json;

namespace S100FC
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

namespace S100FC.Catalogues
{
    public record FeatureType(string Code);

    public record InformationType(string Code);

    public record AssociationType(string Code);

    public sealed class FeatureCatalogue
    {
        public FeatureCatalogue(string productId, Version versionNumber) {
            this.ProductID = productId ?? throw new System.ArgumentNullException(nameof(productId));
            this.VersionNumber = versionNumber ?? throw new System.ArgumentNullException(nameof(versionNumber));
        }

        public string ProductID { get; private set; }

        public Version VersionNumber { get; private set; }

        public Assembly? Assembly { get; set; } = null;

        public ImmutableArray<FeatureType> FeatureTypes { get; set; } = ImmutableArray<FeatureType>.Empty;

        public ImmutableArray<AssociationType> FeatureAssociationTypes { get; set; } = ImmutableArray<AssociationType>.Empty;

        public ImmutableArray<InformationType> InformationTypes { get; set; } = ImmutableArray<InformationType>.Empty;

        public ImmutableArray<AssociationType> InformationAssociationTypes { get; set; } = ImmutableArray<AssociationType>.Empty;

        public Func<Primitives, ImmutableArray<FeatureType>> FeatureTypesByPrimitive { get; set; } = (p) => ImmutableArray<FeatureType>.Empty;

        public JsonSerializerOptions DefaultJsonOptions { get; init; } = new JsonSerializerOptions();

        public string DefaultNamespace => $"S100FC.{this.ProductID.Remove(1, 1)}";

        public static string Namespace(string ps, string types) => $"S100FC.{ps.ToUpperInvariant().Replace("-", string.Empty)}.{types}";

        public static ImmutableArray<FeatureCatalogue> Catalogues => ImmutableArray.Create<FeatureCatalogue>(new FeatureCatalogue[]{
            new("S-101", S100FC.S101.Summary.Version) {
                Assembly = typeof(S100FC.S101.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(S100FC.S101.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S101.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(S100FC.S101.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S101.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimitive = (p) => ImmutableArray.Create<FeatureType>(S100FC.S101.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = S100FC.S101.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-122", S100FC.S122.Summary.Version) {
                Assembly = typeof(S100FC.S122.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(S100FC.S122.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S122.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(S100FC.S122.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S122.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimitive = (p) => ImmutableArray.Create<FeatureType>(S100FC.S122.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = S100FC.S122.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-123", S100FC.S123.Summary.Version) {
                Assembly = typeof(S100FC.S123.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(S100FC.S123.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S123.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(S100FC.S123.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S123.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimitive = (p) => ImmutableArray.Create<FeatureType>(S100FC.S123.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = S100FC.S123.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-124", S100FC.S124.Summary.Version) {
                Assembly = typeof(S100FC.S124.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(S100FC.S124.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S124.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(S100FC.S124.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S124.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimitive = (p) => ImmutableArray.Create<FeatureType>(S100FC.S124.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = S100FC.S124.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-125", S100FC.S125.Summary.Version) {
                Assembly = typeof(S100FC.S125.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(S100FC.S125.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S125.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(S100FC.S125.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S125.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimitive = (p) => ImmutableArray.Create<FeatureType>(S100FC.S125.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = S100FC.S125.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-127", S100FC.S127.Summary.Version) {
                Assembly = typeof(S100FC.S127.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(S100FC.S127.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S127.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(S100FC.S127.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S127.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimitive = (p) => ImmutableArray.Create<FeatureType>(S100FC.S127.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = S100FC.S127.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-128", S100FC.S128.Summary.Version) {
                Assembly = typeof(S100FC.S128.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(S100FC.S128.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S128.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(S100FC.S128.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S128.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimitive = (p) => ImmutableArray.Create<FeatureType>(S100FC.S128.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = S100FC.S128.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            new("S-131", S100FC.S131.Summary.Version) {
                Assembly = typeof(S100FC.S131.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(S100FC.S131.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S131.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(S100FC.S131.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S131.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimitive = (p) => ImmutableArray.Create<FeatureType>(S100FC.S131.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = S100FC.S131.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
            //new("S-201", S100FC.S201.Summary.Version) {
            //    Assembly = typeof(S100FC.S201.Summary).Assembly,
            //    FeatureTypes = ImmutableArray.Create<FeatureType>(S100FC.S201.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
            //    InformationTypes = ImmutableArray.Create<InformationType>(S100FC.S201.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
            //    InformationAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S201.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            //    FeatureTypesByPrimivive = (p) => ImmutableArray.Create<FeatureType>(S100FC.S201.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
            //    DefaultJsonOptions = new JsonSerializerOptions {
            //        Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            //        PropertyNameCaseInsensitive = true,
            //        WriteIndented = false,
            //        TypeInfoResolver = S100FC.S201.Summary.SharedBindingResolver(),
            //    }
            //},
            new("S-501", S100FC.S501.Summary.Version) {
                Assembly = typeof(S100FC.S501.Summary).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(S100FC.S501.Summary.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S501.Summary.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(S100FC.S501.Summary.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(S100FC.S501.Summary.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                FeatureTypesByPrimitive = (p) => ImmutableArray.Create<FeatureType>(S100FC.S501.Summary.PrimitiveFeatures(p).Select(e=> new FeatureType(e)).ToArray()),
                DefaultJsonOptions = S100FC.S501.Extensions.AppendTypeInfoResolver(new JsonSerializerOptions {
                    Encoder =System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                    PropertyNameCaseInsensitive = true,
                    WriteIndented = false,
                })
            },
        });
    }
}

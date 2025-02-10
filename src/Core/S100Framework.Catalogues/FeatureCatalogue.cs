using System.Collections.Immutable;
using System.Reflection;

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

        public string DefaultNamespace => $"S100Framework.DomainModel.{ProductID.Remove(1, 1)}";

        public static string Namespace(string ps, string types) => $"S100Framework.DomainModel.{ps.ToUpperInvariant().Replace("-", string.Empty)}.{types}";

        public static ImmutableArray<FeatureCatalogue> Catalogues => ImmutableArray.Create<FeatureCatalogue>(new FeatureCatalogue[]{
            new("S-101", DomainModel.S101.Information.Version) {
                Assembly = typeof(DomainModel.S101.Information).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S101.Information.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S101.Information.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S101.Information.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S101.Information.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            },
            new("S-122", DomainModel.S122.Information.Version) {
                Assembly = typeof(DomainModel.S122.Information).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S122.Information.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S122.Information.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S122.Information.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S122.Information.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            },
            new("S-124", DomainModel.S124.Information.Version) {
                Assembly = typeof(DomainModel.S124.Information).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S124.Information.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S124.Information.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S124.Information.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S124.Information.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            },
            new("S-128", DomainModel.S128.Information.Version) {
                Assembly = typeof(DomainModel.S128.Information).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S128.Information.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S128.Information.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S128.Information.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S128.Information.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            },
            new("S-131", DomainModel.S131.Information.Version) {
                Assembly = typeof(DomainModel.S131.Information).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S131.Information.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S131.Information.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S131.Information.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S131.Information.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            },
            //new("S-201", DomainModel.S201.Information.Version) {
            //    Assembly = typeof(DomainModel.S201.Information).Assembly,
            //    FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S201.Information.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
            //    InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S201.Information.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
            //    InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S201.Information.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            //}
            new("S-501", DomainModel.S501.Information.Version) {
                Assembly = typeof(DomainModel.S501.Information).Assembly,
                FeatureTypes = ImmutableArray.Create<FeatureType>(DomainModel.S501.Information.FeatureTypes.Select(e=>new FeatureType(e)).ToArray()),
                FeatureAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S501.Information.FeatureAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
                InformationTypes = ImmutableArray.Create<InformationType>(DomainModel.S501.Information.InformationTypes.Select(e=>new InformationType(e)).ToArray()),
                InformationAssociationTypes = ImmutableArray.Create<AssociationType>(DomainModel.S501.Information.InformationAssociationTypes.Select(e=>new AssociationType(e)).ToArray()),
            },
        });
    }
}

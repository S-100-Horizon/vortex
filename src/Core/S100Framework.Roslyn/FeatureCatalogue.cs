using System.Collections.Immutable;
using System.Reflection;

namespace S100Framework
{
    public record FeatureType(string Code, string Name);

    public record InformationType(string Code, string Name);

    public sealed class FeatureCatalogue
    {
        public FeatureCatalogue(string productId, string versionNumber) {
            ProductID = productId ?? throw new System.ArgumentNullException(nameof(productId));
            VersionNumber = versionNumber ?? throw new System.ArgumentNullException(nameof(versionNumber));
        }

        public string ProductID { get; private set; }

        public string VersionNumber { get; private set; }

        public Assembly? Assembly { get; set; } = null;

        public ImmutableArray<FeatureType> FeatureTypes { get; set; } = ImmutableArray<FeatureType>.Empty;

        public ImmutableArray<InformationType> InformationTypes { get; set; } = ImmutableArray<InformationType>.Empty;
    }
}

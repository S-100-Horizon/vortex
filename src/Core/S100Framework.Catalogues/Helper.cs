using S100Framework.DomainModel;

namespace S100Framework.Catalogues
{
    public static class Helper
    {
        public static ISummary? GetSummary(string ps) {
            if (string.IsNullOrEmpty(ps)) return null;

            return ps.ToLowerInvariant() switch {
                "s101" or "s-101" => new DomainModel.S101.Summary(),
                "s122" or "s-122" => new DomainModel.S122.Summary(),
                "s123" or "s-123" => new DomainModel.S123.Summary(),
                "s124" or "s-124" => new DomainModel.S124.Summary(),
                "s127" or "s-127" => new DomainModel.S127.Summary(),
                "s128" or "s-128" => new DomainModel.S128.Summary(),
                "s131" or "s-131" => new DomainModel.S131.Summary(),
                "s201" or "s-201" => new DomainModel.S201.Summary(),
                "s501" or "s-501" => new DomainModel.S501.Summary(),
                _ => null
            };
        }
    }
}

namespace S100Framework.WPF
{
    public record InformationTypeId(string Code, string Id)
    {
        public override string ToString() => $"{this.Code}::{this.Id}";
    }

    public record FeatureTypeId(string Code, string Id)
    {
        public override string ToString() => $"{this.Code}::{this.Id}";
    }
}

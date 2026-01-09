using ArcGIS.Core.Geometry;

namespace S100Framework.Applications.S57.esri
{
    internal abstract class S57Object : object
    {
        public Guid GlobalId { get; set; }
        public Geometry? Shape { get; set; }
        public string? TableName { get; set; }
        public int? PLTS_COMP_SCALE { get; set; }
        public int? FcSubtype { get; set; }

        public int? SCAMIN_STEP { get; set; } = default;
    }
}

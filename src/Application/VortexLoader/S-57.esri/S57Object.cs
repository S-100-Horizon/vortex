using ArcGIS.Core.Geometry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Applications.S57.esri
{
    internal abstract class S57Object : object
    {
        public Guid GlobalId { get; set; }
        public Geometry? Shape { get; set; }
        public string? TableName { get; set; }
        public int? PLTS_COMP_SCALE { get; set; }
        public int? FcSubtype { get; set; }

    }
}

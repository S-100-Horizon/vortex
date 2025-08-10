using ArcGIS.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Settings
{
    public class NauticalProducts
    {
        public Connection[] Connections { get; set; } = [];
    }

    public record Connection(string ProductSpecification, Uri ConnectionFile);
}

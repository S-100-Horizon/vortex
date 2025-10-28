using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.WPF
{
    public record InformationTypeId(string Code, string Id)
    {
        public override string ToString() => $"{Code}::{Id}";
    }

    public record FeatureTypeId(string Code, string Id)
    {
        public override string ToString() => $"{Code}::{Id}";
    }
}

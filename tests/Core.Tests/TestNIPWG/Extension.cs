using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.DomainModel.S128
{
    public static class Extension
    {
        public static FeatureTypes.ElectronicProduct ApplyScamin(this FeatureTypes.ElectronicProduct feature, int compilationScale) {
            feature.minimumDisplayScale = compilationScale switch {
                < 22000 => 22000,
                < 90000 => 90000,
                < 180000 => 180000,
                < 700000 => 70000,
                _ => default,
            };
            feature.maximumDisplayScale = compilationScale switch {
                >= 700000 => 180000,
                >= 180000 => 90000,
                >= 90000 => 22000,
                >= 22000 => 12000,
                _ => 1,
            };

            return feature;
        }
    }
}

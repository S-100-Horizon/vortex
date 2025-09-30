using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.InformationTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S100Framework.Applications
{
    internal class InformationResult {

        internal List<information> information { get; set; } = new();
        internal List<NauticalInformation> NauticalInformation { get; set; } = new();
    }
}

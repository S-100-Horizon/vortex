using S100Framework.DomainModel;
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

        // Simple text
        internal List<information> information { get; set; } = new();

        // File references
        internal List<NauticalInformation> NauticalInformation { get; set; } = new();


        internal List<informationBinding> InformationBindings { get; set; } = new();
    }
}

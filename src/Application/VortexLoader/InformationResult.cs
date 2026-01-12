using S100FC;
using S100FC.S101.ComplexAttributes;
using S100FC.S101.InformationTypes;

namespace S100Framework.Applications
{
    internal class InformationResult
    {

        // Simple text
        internal List<information> information { get; set; } = [];

        // File references
        internal List<NauticalInformation> NauticalInformation { get; set; } = [];


        internal List<informationBinding> InformationBindings { get; set; } = [];
    }
}

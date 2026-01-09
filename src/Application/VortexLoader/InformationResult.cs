using S100Framework.AttributeModel;
using S100Framework.AttributeModel.S101.ComplexAttributes;
using S100Framework.AttributeModel.S101.InformationTypes;

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

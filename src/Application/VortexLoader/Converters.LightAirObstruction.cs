using ArcGIS.Core.Data;
using S100Framework.Applications.S57.esri;
using S100Framework.Applications.Singletons;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;

namespace S100Framework.Applications
{
    internal static partial class Converters
    {

        /*
			--v --cmd NIS --target "\\nas.gst.dk\ncps\modeloffice\vortex\connections\s100ed6_traditional(s101).sde" --source "C:\Vortex\replica.gdb" --query "PLTS_COMP_SCALE = 22000" --skinofearthonly false --notespath "G:\indigo\ENC\NotesAndPictures" --scaminfiles "G:\indigo\Configuration"
			--v --cmd NIS --target "C:\Vortex\s100ed6.gdb" --source "C:\Vortex\replica.gdb" --query "PLTS_COMP_SCALE = 22000" --skinofearthonly false --notespath "G:\indigo\ENC\NotesAndPictures" --scaminfiles "G:\indigo\Configuration"
    		--v --cmd NIS --target "https://enterprise.gst.dk/arcgisserver/rest/services/S-100/s100ed4raw/FeatureServer" --source "C:\Vortex\replica.gdb" --query "PLTS_COMP_SCALE = 22000" --skinofearthonly true --notespath "G:\indigo\ENC\NotesAndPictures"
			--v --cmd NIS --target "C:\Vortex\s100ed4.gdb" --source "C:\Vortex\replica.gdb" --query "PLTS_COMP_SCALE = 22000" --skinofearthonly true --notespath "G:\indigo\ENC\NotesAndPictures"
			--v --cmd NIS --target "C:\Vortex\connections\nis.sde" --source "C:\Vortex\replica.gdb" --query "PLTS_COMP_SCALE = 22000" --skinofearthonly true --notespath "G:\indigo\ENC\NotesAndPictures"
			--v --cmd NIS --target "C:\Vortex\connections\SQLServer-ncps-mssql-test-s100ed4_traditional(s101_dbo).sde" --source "C:\Vortex\replica.gdb" --query "PLTS_COMP_SCALE = 22000" --skinofearthonly true --notespath "G:\indigo\ENC\NotesAndPictures"
			--v --cmd NIS --target "C:\Vortex\s100ed4.gdb" --source "C:\Vortex\replica.gdb" --query "PLTS_COMP_SCALE = 22000" --skinofearthonly true --notespath "G:\indigo\ENC\NotesAndPictures"
			--v --cmd NIS --target "C:\Vortex\s100ed6.gdb" --source "C:\Vortex\replica.gdb" --query "PLTS_COMP_SCALE = 22000" --skinofearthonly false --notespath "G:\indigo\ENC\NotesAndPictures" --scaminfiles "G:\indigo\Configuration"
			--geodatabase \\nas.gst.dk\ncps\modeloffice\vortex\connections\s100ed6_traditional(s101).sde -d DK40543E
			--geodatabase "\\nas.gst.dk\public\projektdata\projekter\S-101_Conversion\All\s100ed6.gdb"
			--geodatabase "\\nas.gst.dk\ncps\modeloffice\vortex\connections\s100ed6_traditional(s101).sde" -d DK40349E
			--geodatabase "\\nas.gst.dk\ncps\modeloffice\vortex\connections\s100ed6_traditional(s101).sde" -d DK40351E
			--geodatabase \\nas.gst.dk\ncps\modeloffice\vortex\connections\s100ed6_traditional(s101).sde -d DK40543E
			--geodatabase "\\nas.gst.dk\public\projektdata\projekter\S-101_Conversion\20250522-s100ed6_traditional(s101).sde" -d DKLALAL
			"C:\Program Files\s100compiler\s100compiler.exe" -C 101DK40349E -d C:\Temp\s100\results -f C:\Temp\101DK40349E.yaml -c C:\Temp\s100\FeatureCatalogue.xml
			"C:\Program Files\s100compiler\s100compiler.exe" -C 101DK40545E -d C:\Temp\s100\results -f C:\Temp\101DK40545E.yaml -c C:\Temp\s100\FeatureCatalogue.xml
		*/

        internal static LightAirObstruction CreateLightAirObstruction(AidsToNavigationP current, int? scaleMinimum, Geodatabase source) {
            var instance = new LightAirObstruction();

            if (current.COLOUR != default) {
                instance.colour = ImporterNIS.GetColours< LightAirObstruction>(current.COLOUR);
            }

            if (current.EXCLIT.HasValue) {
                instance.exhibitionConditionOfLight = EnumHelper.GetEnumValue<LightAirObstruction,exhibitionConditionOfLight>(current.EXCLIT.Value);
            }

            instance.featureName = ImporterNIS.GetFeatureName(current.OBJNAM, current.NOBJNM);

            DateHelper.TryGetFixedDateRange(current.DATSTA, current.DATEND, out var dateRange);
            if (dateRange != default) {
                instance.fixedDateRange = dateRange;
            }

            // flareBearing is not populated. New field.

            // TODO: Interoperability identifier                            
            if (current.HEIGHT.HasValue && current.HEIGHT.Value != -32767m) {
                instance.height = current.HEIGHT.Value;
            }
            else {
                instance.height = default(decimal?);
            }

            if (current.LITVIS != null) {
                instance.lightVisibility = EnumHelper.GetEnumValues<LightAirObstruction,lightVisibility>(current.LITVIS);
            }

            if (current.MLTYLT.HasValue) {
                instance.multiplicityOfFeatures = new multiplicityOfFeatures() {
                    multiplicityKnown = true,
                    numberOfFeatures = current.MLTYLT
                };
            }

            DateHelper.TryGetPeriodicDateRange(current.PERSTA, current.PEREND, out var periodicDateRange);
            if (periodicDateRange != default) {
                instance.periodicDateRange = periodicDateRange;
            }

            instance.rhythmOfLight = ImporterNIS.GetRythmOfLight<LightAirObstruction>(current);

            if (current.STATUS != default) {
                instance.status = ImporterNIS.GetStatus(current.STATUS);
            }

            if (current.VALNMR.HasValue) {
                instance.valueOfNominalRange = current.VALNMR.Value;
            }
            // todo: mean sea level til baltic.
            instance.verticalDatum = ImporterNIS.GetVerticalDatum<LightAirObstruction>(current.VERDAT ?? 3);


            if (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {
                string subtype = "";
                if (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))
                    throw new NotSupportedException($"Unknown subtype for {current.TableName}, {current.FCSUBTYPE.Value}");
                instance.scaleMinimum = Scamin.Instance.GetMinimumScale(current.SHAPE, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);
            }


            ImporterNIS.AddInformation(instance.information, current.OBJECTID!.Value, current.TableName!, current.NTXTDS, current.TXTDSC, current.INFORM, current.NINFOM);

            return instance;
        }


    }
}

using S100Framework.Applications;
using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using IO = System.IO;
using ArcGIS.Core.Internal.CIM;
using System.Security.Principal;
using Xunit.Abstractions;
using ArcGIS.Core.Geometry;
using Microsoft.VisualBasic;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101;
using System.Text;

namespace TestNisImporter
{
    public class TestNisImporter
    {

        public TestNisImporter() {
            ArcGIS.Core.Hosting.Host.Initialize();
        }


        [Fact]
        public void NoteLoaderTest() {
            var notesPath = @"G:\indigo\ENC\NotesAndPictures";

            foreach (var notePath in Directory.GetFiles(notesPath, "*.txt", SearchOption.AllDirectories)) {
                var note = new Note(notePath);
                //Assert.True(string.IsNullOrEmpty(note.Header));
                Assert.True(!string.IsNullOrEmpty(note.Content));

            }
        }

        [Fact]
        public void GenerateNisModel() {
            var featureclasses = new List<string> { "PLTS_SpatialAttributeL",
                                            "TidesAndVariationsA",
                                            "TidesAndVariationsL",
                                            "TidesAndVariationsP",
                                            "SeabedL",
                                            "SeabedP",
                                            "SeabedA",
                                            "DangersL",
                                            "DangersP",
                                            "DangersA",
                                            "DepthsL",
                                            "OffshoreInstallationsL",
                                            "OffshoreInstallationsA",
                                            "MetaDataP",
                                            "TracksAndRoutesA",
                                            "TracksAndRoutesL",
                                            "TracksAndRoutesP",
                                            "AidsToNavigationP",
                                            "IceFeaturesA",
                                            "MilitaryFeaturesA",
                                            "MilitaryFeaturesP",
                                            "UserDefinedFeaturesA",
                                            "UserDefinedFeaturesP",
                                            "UserDefinedFeaturesL",
                                            "DepthsA",
                                            "SoundingsP",
                                            "PortsAndServicesP",
                                            "PortsAndServicesL",
                                            "PortsAndServicesA",
                                            "CulturalFeaturesA",
                                            "CulturalFeaturesL",
                                            "CulturalFeaturesP",
                                            "NaturalFeaturesP",
                                            "NaturalFeaturesL",
                                            "NaturalFeaturesA",
                                            "CoastlineL",
                                            "CoastlineP",
                                            "CoastlineA",
                                            "RegulatedAreasAndLimitsL",
                                            "RegulatedAreasAndLimitsP",
                                            "RegulatedAreasAndLimitsA",
                                            "MetaDataA",
                                            "MetaDataL",
                                            "OffshoreInstallationsP",
                                            "ClosingLinesL",
                                            "ProductCoverage",
                                            //"ProductRestrictions"
            };
            var tables = new List<string> { //"ProductExports",
                                            "ProductDefinitions"
                                          };

            var sourcePath = @$"{Environment.GetEnvironmentVariable("OneDrive")}\ArcGIS\Projects\Vortex\replica.gdb";
            var source = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(sourcePath))));

            string filePath = IO.Path.GetFullPath(IO.Path.Combine(@".\..\..\..\..\..\..\src\Application\VortexLoader\S-57.esri\S57EsriAuto.cs"));
            StringBuilder csFile = new StringBuilder();

            List<Dataset> datasets = new List<Dataset>();
            foreach (var featureclass in featureclasses) {
                datasets.Add(source.OpenDataset<FeatureClass>(featureclass));
            }
            foreach (var table in tables) {
                datasets.Add(source.OpenDataset<Table>(table));
            }

            using (StreamWriter file = new StreamWriter(filePath)) {
                csFile.AppendLine("using ArcGIS.Core.Data;");
                csFile.AppendLine("using ArcGIS.Core.Geometry;");
                csFile.AppendLine("using System.ComponentModel;");
                csFile.AppendLine("namespace VortexLoader.S57Auto.esri");
                csFile.AppendLine("{");

                foreach (var dataset in datasets) {
                
                    StringBuilder fields = new StringBuilder();
                    StringBuilder ctor = new StringBuilder();
                    StringBuilder objectClass = new StringBuilder();

                    objectClass.AppendLine($"\tinternal class {dataset.GetName()} {{");

                    ctor.AppendLine($"\t\tpublic {dataset.GetName()} (Feature feature) {{");

                    IReadOnlyList<ArcGIS.Core.Data.Field> datasetfields = default;
                    if (dataset is Table) {
                        datasetfields = (dataset as Table).GetDefinition().GetFields();
                    }
                    if (dataset is FeatureClass) {
                        datasetfields = (dataset as FeatureClass).GetDefinition().GetFields();
                    }


                    var fieldInfo = (Type: "Int32", Conversion: "Convert.ToInt32", DefaultValue: "default", Alias: string.Empty);
                    foreach (var field in datasetfields) {

                        fieldInfo = field.FieldType switch {
                            (FieldType)esriFieldType.esriFieldTypeInteger => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", string.Empty),
                            (FieldType)esriFieldType.esriFieldTypeString => (Type: "internal string?", Conversion: "Convert.ToString", Default: "default", string.Empty),
                            (FieldType)esriFieldType.esriFieldTypeSmallInteger => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", string.Empty),
                            (FieldType)esriFieldType.esriFieldTypeDouble => (Type: "internal decimal?", Conversion: "Convert.ToDecimal", Default: "default", string.Empty),
                            (FieldType)esriFieldType.esriFieldTypeSingle => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", string.Empty),
                            (FieldType)esriFieldType.esriFieldTypeDate => (Type: "internal DateTime?", Conversion: "Convert.ToDateTime", Default: "default", string.Empty),
                            (FieldType)esriFieldType.esriFieldTypeGUID => (Type: "internal Guid?", Conversion: "Guid.Parse", Default: "Guid.Empty", string.Empty),
                            //(FieldType)esriFieldType.esriFieldTypeBlob => (Type: "byte[]", Conversion: "", Default: "new byte[fs.Length]", string.Empty),
                            //(FieldType)esriFieldType.esriFieldTypeRaster => (Type: "Raster", Conversion: "", Default: "default", string.Empty),
                            (FieldType)esriFieldType.esriFieldTypeOID => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", string.Empty),
                            (FieldType)esriFieldType.esriFieldTypeGlobalID => (Type: "internal Guid", Conversion: "Guid.Parse", Default: "Guid.Empty", string.Empty),
                            (FieldType)esriFieldType.esriFieldTypeGeometry => (Type: "internal Geometry?", Conversion: "(Geometry?)", Default: "default", string.Empty),
                            _ => throw new IndexOutOfRangeException(),
                        };

                        fieldInfo.Alias = field.AliasName;

                        var fieldValue = "";

                        if (string.IsNullOrEmpty(fieldInfo.Conversion)) {
                            fieldValue = $@"feature[""{field.Name.ToUpper()}""];";
                        }
                        else {
                            fieldValue = $@"{fieldInfo.Conversion}(feature[""{field.Name.ToUpper()}""])";
                        }
                        if (fieldInfo.Type.ToLower().Contains("guid")) {
                            fieldValue = $@"{fieldInfo.Conversion}(Convert.ToString(feature[""{field.Name.ToUpper()}""]))";
                        }


                            fields.AppendLine($"\t\t[Description(\"{fieldInfo.Alias}\")]");
                        fields.AppendLine($"\t\t{fieldInfo.Type} {field.Name.ToUpper()} = {fieldInfo.DefaultValue};");

                        ctor.AppendLine($"\t\t\tif (DBNull.Value != feature[\"{field.Name.ToUpper()}\"] && feature[\"{field.Name.ToUpper()}\"] is not null) {{");
                        ctor.AppendLine($"\t\t\t\t{field.Name.ToUpper()} = {fieldValue};");
                        ctor.AppendLine($"\t\t\t}}");
                    }

                    ctor.AppendLine("\t\t}");
                    ctor.AppendLine("\t}");

                    objectClass.Append(fields);
                    objectClass.Append(ctor);
                    csFile.Append(objectClass);
                    
                    //csFile.Append(@"}");

                }



                csFile.AppendLine(@"}");
                file.WriteLine(csFile.ToString());
            }
            

        }
    }
}

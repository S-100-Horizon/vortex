using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using S100Framework.Applications;
using System.Text;
using System.Text.RegularExpressions;
using Xunit.Abstractions;
using IO = System.IO;

namespace TestNisImporter
{
    public class TestNisImporter
    {

        private readonly ITestOutputHelper _output;

        public TestNisImporter(ITestOutputHelper output) {
            this._output = output;
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
        public void GenerateSubtypes() {
            var sourcePath = @$"{Environment.GetEnvironmentVariable("OneDrive")}\ArcGIS\Projects\Vortex\replica.gdb";
            var source = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(sourcePath))));

            StringBuilder csSubtypes = new StringBuilder();

            var featureClass = source.OpenDataset<FeatureClass>("PortsAndServicesP");

            var subtypes = featureClass.GetDefinition().GetSubtypes();

            var sortedDict = new SortedDictionary<int, string>();

            foreach (var subtype in subtypes) {
                sortedDict.Add(subtype.GetCode(), subtype.GetName());
            }

            foreach (var keyValuePair in sortedDict) {
                csSubtypes.AppendLine($"\t\tcase {keyValuePair.Key}: {{ // {keyValuePair.Value}");
                csSubtypes.AppendLine($"\t\t}}");
                csSubtypes.AppendLine($"\t\tbreak;");
            }

            csSubtypes.AppendLine($"\t\tdefault:");
            csSubtypes.AppendLine($"\t\t\t// code block");
            csSubtypes.AppendLine($"\t\t\tSystem.Diagnostics.Debugger.Break();");
            csSubtypes.AppendLine($"\t\tbreak;");

            Console.WriteLine(csSubtypes.ToString());
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
                                            "ProductDefinitions",
                                            "PLTS_Collections",
                                            "PLTS_Frel",
                                            "PLTS_Master_Slaves"
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
                csFile.AppendLine("/* THIS FILE IS AUTO GENERATED BY UNIT TEST GenerateNisModel */");
                csFile.AppendLine("/* Run test. GenerateNisModel and copy contents from the output file and change the namespace once compiling. */");
                csFile.AppendLine("/* If error in auto generated file just clear it's contents and run again. */");
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


                    IReadOnlyList<ArcGIS.Core.Data.Field> datasetfields = new List<ArcGIS.Core.Data.Field>();

                    if (dataset is FeatureClass) {
                        datasetfields = ((FeatureClass)dataset).GetDefinition().GetFields();
                        ctor.AppendLine($"\t\tpublic {dataset.GetName()} (Feature feature) {{");
                    } else if (dataset is Table) {
                            datasetfields = ((Table)dataset).GetDefinition().GetFields();
                            ctor.AppendLine($"\t\tpublic {dataset.GetName()} (Row row) {{");
                    }



                    var fieldInfo = (Type: "Int32", Conversion: "Convert.ToInt32", DefaultValue: "default", Alias: string.Empty);

                    foreach (var field in datasetfields) {

                        fieldInfo = field.FieldType switch {
                            (FieldType)esriFieldType.esriFieldTypeBigInteger => (Type: "internal long?", Conversion: "Convert.ToLong", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeInteger => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeString => (Type: "internal string?", Conversion: "Convert.ToString", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeSmallInteger => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeDouble => (Type: "internal decimal?", Conversion: "Convert.ToDecimal", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeSingle => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeDate => (Type: "internal DateTime?", Conversion: "Convert.ToDateTime", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeGUID => (Type: "internal Guid", Conversion: "Guid.Parse", Default: "Guid.Empty", Alias: field.AliasName),
                            //(FieldType)esriFieldType.esriFieldTypeBlob => (Type: "byte[]", Conversion: "", Default: "new byte[fs.Length]", field.AliasName),
                            //(FieldType)esriFieldType.esriFieldTypeRaster => (Type: "Raster", Conversion: "", Default: "default", field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeOID => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeGlobalID => (Type: "internal Guid", Conversion: "Guid.Parse", Default: "Guid.Empty", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeGeometry => (Type: "internal Geometry?", Conversion: "(Geometry?)", Default: "default", Alias: field.AliasName),
                            _ => throw new IndexOutOfRangeException(),
                        };

                        var fieldValue = "";

                        if (dataset is FeatureClass) {
                            if (string.IsNullOrEmpty(fieldInfo.Conversion)) {
                                fieldValue = $@"feature[""{field.Name.ToUpper()}""];";
                            }
                            else {
                                fieldValue = $@"{fieldInfo.Conversion}(feature[""{field.Name.ToUpper()}""])";
                            }
                            if (fieldInfo.Type.ToLower().Contains("guid")) {
                                fieldValue = $@"Guid.TryParse(Convert.ToString(feature[""{field.Name.ToUpper()}""]), out {field.Name.ToUpper()})";
                            }

                        }
                        else if (dataset is Table) {
                            if (string.IsNullOrEmpty(fieldInfo.Conversion)) {
                                fieldValue = $@"row[""{field.Name.ToUpper()}""];";
                            }
                            else {
                                fieldValue = $@"{fieldInfo.Conversion}(row[""{field.Name.ToUpper()}""])";
                            }
                            if (fieldInfo.Type.ToLower().Contains("guid")) {
                                fieldValue = $@"Guid.TryParse(Convert.ToString(row[""{field.Name.ToUpper()}""]), out {field.Name.ToUpper()})";
                            }

                        }

                        fields.AppendLine($"");
                        fields.AppendLine($"\t\t/// <summary>");
                        fields.AppendLine($"\t\t/// {fieldInfo.Alias}");
                        fields.AppendLine($"\t\t/// </summary>");
                        fields.AppendLine($"\t\t[Description(\"{fieldInfo.Alias}\")]");
                        fields.AppendLine($"\t\t{fieldInfo.Type} {field.Name.ToUpper()} = {fieldInfo.DefaultValue};");

                        if (dataset is FeatureClass) {
                            ctor.AppendLine($"\t\t\tif (DBNull.Value != feature[\"{field.Name.ToUpper()}\"] && feature[\"{field.Name.ToUpper()}\"] is not null) {{");
                        }
                        else if (dataset is Table) {
                            ctor.AppendLine($"\t\t\tif (DBNull.Value != row[\"{field.Name.ToUpper()}\"] && row[\"{field.Name.ToUpper()}\"] is not null) {{");
                        }

                        if (fieldInfo.Type.ToLower().Contains("guid")) {
                            ctor.AppendLine($"\t\t\t\t{fieldValue};");
                        }
                        else {
                            ctor.AppendLine($"\t\t\t\t{field.Name.ToUpper()} = {fieldValue};");
                        }
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


        [Fact]
        public void BuildImportS57ToGeodatabaseScripts() {
            var root = new IO.DirectoryInfo(@"c:\temp\ENC\");

            var python = new StringBuilder();

            foreach (var enc in root.EnumerateDirectories()) {
                var command = ImportS57ToGeodatabase(enc, "geodatabase.gdb", (e) => true);

                python.AppendLine(command);
            }

            _output.WriteLine(python.ToString());
        }

        private static string ImportS57ToGeodatabase(DirectoryInfo folder, string connection, Func<string, bool> include) {
            var tasks = new List<string>();

            var regex = new Regex(@"\d{3}$");

            foreach (var file in folder.GetFiles("*.000").OrderBy(e => IO.Path.GetFileNameWithoutExtension(e.FullName))) {
                var name = IO.Path.GetFileNameWithoutExtension(file.FullName);

                if (!include.Invoke(name))
                    continue;

                var updates = folder.GetFiles("*.*", SearchOption.TopDirectoryOnly).Where(e => !e.Extension.Equals(".000") && !e.Extension.Equals(".031") && regex.IsMatch(e.Name)).ToList();


                tasks.Add($"arcpy.maritime.ImportS57ToGeodatabase(" + Environment.NewLine +
                $"    in_base_cell = r\"{file.FullName}\"," + Environment.NewLine +
                $"    target_workspace=r\"{connection}\"," + Environment.NewLine +
                $"    in_update_cells=r\"{string.Join(';', updates)}\"," + Environment.NewLine +
                 "    in_product_config=None" + Environment.NewLine +
                ")" + Environment.NewLine);
            }

            var commands = string.Join(Environment.NewLine, tasks);

            return commands;
        }

    }
}

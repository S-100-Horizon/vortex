using ArcGIS.Core.CIM;
using ArcGIS.Core.Data;
using S100Framework.Applications;
using System.Globalization;
using System.Text;
using System.Text.RegularExpressions;
using Xunit.Abstractions;
using IO = System.IO;

namespace TestNisImporter
{
    public class TestNisImporter
    {
        internal struct Sequence
        {
            public decimal Duration { get; set; }
            public int Status { get; set; }

            public Sequence(decimal duration, int status) {
                this.Duration = duration;
                this.Status = status;
            }
        }

        private readonly ITestOutputHelper _output;

        public TestNisImporter(ITestOutputHelper output) {
            this._output = output;
            ArcGIS.Core.Hosting.Host.Initialize();
        }

        [Fact]
        public void TestStatus() {
            // Assert.True(ImporterNIS.GetStatus(status).Count == 2, "");
        }

        [Fact]
        public void TestGetCommunicationChannel() {

            //Assert.True(ImporterNIS.GetCommunicationChannel("[74]")[0] == "[VHF0074]");
            //Assert.True(ImporterNIS.GetCommunicationChannel("[04]")[0] == "[VHF0004]");
            //Assert.True(ImporterNIS.GetCommunicationChannel("[WX1]")[0] == "[WX0001]");
            //Assert.True(ImporterNIS.GetCommunicationChannel("[WX01];[04]")[0] == "[WX0001]");
            //Assert.True(ImporterNIS.GetCommunicationChannel("[WX01];[04]")[1] == "[VHF0004]");
        }

        [Fact]
        public void TestSordat() {
            {
                Assert.True(DateHelper.TryConvertSordat("20200613", out var result));
                Assert.Equal("20200613", result);
            }
            {
                Assert.True(DateHelper.TryConvertSordat("202006", out var result));
                Assert.Equal("202006--", result);
            }
            {
                Assert.True(DateHelper.TryConvertSordat("2008", out var result));
                Assert.Equal("2008----", result);
            }
            {
                Assert.False(DateHelper.TryConvertSordat("200813", out var result));
            }
            {
                Assert.False(DateHelper.TryConvertSordat("20081232", out var result));
            }
        }


        [Fact]
        public void TestVesselSpeedLimitExtraction() {
            string[] inputs = {
                "Motorised navigation faster than 6 knots is prohibited.",
                "Speed limit 10 knots",
                "Speedlimit is 10 Knots.",
                "Speed limit is 3 knots",
                "Speed limit is 12 knots outside the channel",
                "Speedlimit 5 knots",
                "During the period from 1st July to 30th September the speed limit is 10 Knots."
            };

            foreach (var text in inputs) {
                //Assert.True(ImporterNIS.GetVesselSpeedLimit(text).Count > 0);
            }

        }


        [Fact]
        public void TestRounding() {

            Assert.True(RoundToIHO(5.6d) == 5.6d);
        }
        public static double RoundToIHO(double value) {

            if (value < -31d) {
                return Math.Floor(value);
            }
            else if (value < -21.0d) {
                return value % 1 < 0.5 ? Math.Ceiling(value) - 0.5d : Math.Ceiling(value);
            }
            else if (value < 0) {
                return RoundDownwards(value, 1, -0.5d);
            }
            else if (value < 21.0d) {
                return RoundDownwards(value, 1);
            }
            else if (value < 31) {
                return value % 1 < 0.5 ? Math.Floor(value) : Math.Floor(value) + 0.5;
            }

            return Math.Floor(value);
        }
        public static double RoundDownwards(double value, int digits, double offset = 0d) {
            var power10 = 1E1;
            value *= power10;
            value += offset;
            value = Math.Truncate(value);
            return value /= power10;
        }

        [Fact]
        public void TestRadarWaveLength() {
            ////var rwl1 = ImporterNIS.GetRadarWaveLengths("0.10-S");
            //{
            //    ImporterNIS.TryGetRadarWaveLengths("0.03-X,0.10-S", out var lengths);
            //    Assert.True(lengths.Count == 2, "");
            //    Assert.True(lengths[0].radarBand == "X");
            //    Assert.True(lengths[0].waveLengthValue == 0.03d);
            //    Assert.True(lengths[1].radarBand == "S");
            //    Assert.True(lengths[1].waveLengthValue == 0.10d);
            //}
            //{
            //    ImporterNIS.TryGetRadarWaveLengths("0.10-S", out var lengths);
            //    Assert.True(lengths.Count == 1, "");
            //    Assert.True(lengths[0].radarBand == "S");
            //    Assert.True(lengths[0].waveLengthValue == 0.10d);
            //}
        }

        [Fact]
        public void TestScaleMinimum() {
            //ImporterNIS._scaminFilesPath = @"G:\indigo\Configuration";
            //{
            //    var val1 = Scamin.Instance.GetMinimumScale(MapPointBuilder.CreateMapPoint(57.0488, 9.9217, SpatialReferences.WGS84), "DMPGRD_DumpingGround", 22000);
            //    Assert.True(val1.HasValue);
            //    Assert.True(val1.Value == 89999, "Wrong scamin");

            //    var val2 = Scamin.Instance.GetMinimumScale(MapPointBuilder.CreateMapPoint(57.0488, 9.9217, SpatialReferences.WGS84), "DMPGRD_DumpingGroundXX", 22000);
            //    Assert.False(val2.HasValue);
            //}
            //{
            //    var val1 = Scamin.Instance.GetMinimumScale(MapPointBuilder.CreateMapPoint(57.0488, 9.9217, SpatialReferences.WGS84), "FLODOC_FloatingDock", 22000);
            //    Assert.False(val1.HasValue);
            //    Assert.True(val1.GetValueOrDefault() == 44999, "Wrong scamin");

            //    var val2 = Scamin.Instance.GetMinimumScale(MapPointBuilder.CreateMapPoint(57.0488, 9.9217, SpatialReferences.WGS84), "FLODOC_FloatingDock", 22000);
            //    Assert.False(val2.HasValue);
            //    Assert.True(val2.GetValueOrDefault() == 44999, "Wrong scamin");

            //    var val3 = Scamin.Instance.GetMinimumScale(MapPointBuilder.CreateMapPoint(57.0488, 9.9217, SpatialReferences.WGS84), "FLODOC_FloatingDock", 22000);
            //    Assert.False(val3.HasValue);
            //}
            //{
            //    var val1 = Scamin.Instance.GetMinimumScale(MapPointBuilder.CreateMapPoint(57.0488, 9.9217, SpatialReferences.WGS84), "BRIDGE_Bridge", 22000); // step value is null
            //    Assert.False(val1.HasValue);
            //    Assert.True(val1.GetValueOrDefault() == 44999, "Wrong scamin");
            //    var val2 = Scamin.Instance.GetMinimumScale(MapPointBuilder.CreateMapPoint(57.0488, 9.9217, SpatialReferences.WGS84), "DMPGRD_DumpingGroundXX", 22000);
            //    Assert.False(val2.HasValue);
            //}
        }


        [Fact]
        public void TestSignalSequence() {
            string input = "12.5+(34.7)+56.8+(78.9)+(91.2)+23.4+(0.09)";
            List<Sequence> sequences = [];

            string pattern = @"(\d+\.\d+)|\((\d+\.\d+)\)";

            Regex regex = new Regex(pattern);
            MatchCollection matches = regex.Matches(input);

            foreach (Match match in matches) {
                if (!string.IsNullOrEmpty(match.Groups[1].Value)) {
                    var duration = decimal.Parse(match.Groups[1].Value, CultureInfo.InvariantCulture);
                    sequences.Add(new Sequence(duration, 1));
                }
                else if (!string.IsNullOrEmpty(match.Groups[2].Value)) {
                    decimal duration = decimal.Parse(match.Groups[2].Value, CultureInfo.InvariantCulture);
                    sequences.Add(new Sequence(duration, 2));
                }
            }

            Assert.True(sequences[0].Duration == 12.5m, "Duration");
            Assert.True(sequences[0].Status == 1, "Status");
            Assert.True(sequences[1].Duration == 34.7m, "Duration");
            Assert.True(sequences[1].Status == 2, "Status");
            Assert.True(sequences[2].Duration == 56.8m, "Duration");
            Assert.True(sequences[2].Status == 1, "Status");
            Assert.True(sequences[3].Duration == 78.9m, "Duration");
            Assert.True(sequences[3].Status == 2, "Status");
            Assert.True(sequences[4].Duration == 91.2m, "Duration");
            Assert.True(sequences[4].Status == 2, "Status");
            Assert.True(sequences[5].Duration == 23.4m, "Duration");
            Assert.True(sequences[5].Status == 1, "Status");
            Assert.True(sequences[6].Duration == 0.09m, "Duration");
            Assert.True(sequences[6].Status == 2, "Status");
        }

        [Fact]
        public void NoteLoaderTest() {
            var notesPath = @"G:\indigo\ENC\NotesAndPictures";

            foreach (var notePath in Directory.GetFiles(notesPath, "*.txt", SearchOption.AllDirectories)) {
                //var note = new Note(notePath);
                //Assert.True(string.IsNullOrEmpty(note.Header));
                //Assert.True(!string.IsNullOrEmpty(note.Content));

            }
        }

        [Fact]
        public void GenerateSubtypes() {
            var sourcePath = @$"{Environment.GetEnvironmentVariable("OneDrive")}\ArcGIS\Projects\Vortex\replica.gdb";
            var source = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(sourcePath))));

            StringBuilder csSubtypes = new StringBuilder();

            var featureClass = source.OpenDataset<FeatureClass>("MetadataP");
            string shapeType = "Point"; // Area | Point | Line

            var subtypes = featureClass.GetDefinition().GetSubtypes();

            var sortedDict = new SortedDictionary<int, string>();

            foreach (var subtype in subtypes) {
                sortedDict.Add(subtype.GetCode(), subtype.GetName());
            }

            foreach (var keyValuePair in sortedDict) {
                csSubtypes.AppendLine($"\t\tcase {keyValuePair.Key}: {{ // {keyValuePair.Value}");

                csSubtypes.AppendLine($"\t\tvar instance = new XXX(){{");
                csSubtypes.AppendLine($"\t\t}};");

                csSubtypes.AppendLine($"\t\t\tif (current.PLTS_COMP_SCALE.HasValue && current.SHAPE != null) {{");
                csSubtypes.AppendLine($"\t\t\tstring subtype = \"\";");

                csSubtypes.AppendLine($"\t\t\tif (current.TableName != default && current.FCSUBTYPE.HasValue && !Subtypes.Instance.TryGetSubtype(current.TableName, current.FCSUBTYPE.Value, out subtype))");
                csSubtypes.AppendLine($"\t\t\tthrow new NotSupportedException($\"Unknown subtype for {{current.TableName}}, {{current.FCSUBTYPE.Value}}\");");

                csSubtypes.AppendLine($"\t\t\tinstance.scaleMinimum = Scamin.Instance.GetMinimumScale(current, subtype, current.PLTS_COMP_SCALE.Value, isRelatedToStructure: false);");
                csSubtypes.AppendLine($"\t\t\t}}");

                csSubtypes.AppendLine($"\t\t\tif (plts_comp_scale != default) {{");
                csSubtypes.AppendLine($"\t\t\t\t\t//instance.scaleMinimum = plts_comp_scale;");
                csSubtypes.AppendLine($"\t\t\t}}");
                csSubtypes.AppendLine($"");
                //csSubtypes.AppendLine($"\t\t\tAddCondition(instance.condition, feature);");
                //csSubtypes.AppendLine($"\t\t\tAddStatus(instance.status, feature);");
                csSubtypes.AppendLine($"\t\t\tinstance.featureName = GetFeatureName(current.OBJNAM, current.NOBJNM);");
                csSubtypes.AppendLine($"\t\t\tAddInformation(instance.information, feature);");
                csSubtypes.AppendLine($"\t\t\tbuffer[\"ps\"] = ps101;");
                csSubtypes.AppendLine($"\t\t\tbuffer[\"code\"] = instance.GetType().Name;");
                csSubtypes.AppendLine($"\t\t\tbuffer[\"json\"] = System.Text.Json.JsonSerializer.Serialize(instance);");

                //csSubtypes.AppendLine($"\t\t\tbuffer[\"shape\"] = current.SHAPE;");
                //csSubtypes.AppendLine($"\t\t\tinsert.Insert(buffer);");
                //csSubtypes.AppendLine($"\t\t\tLogger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance));");
                csSubtypes.AppendLine($"\t\t\tSetShape(buffer, current.SHAPE);");

                csSubtypes.AppendLine($"\t\t\tvar featureN = featureClass.CreateRow(buffer);");
                csSubtypes.AppendLine($"\t\t\tvar name = Convert.ToString(featureN[\"name\"]) ?? \"Unknown name\";");

                csSubtypes.AppendLine($"\t\t\tif (FeatureRelations.Instance.HasRelated(current.GLOBALID)) {{");
                csSubtypes.AppendLine($"\t\t\t\trelatedEquipment?.CreateRelated{shapeType}Equipment(current, instance, name, target, source);");
                csSubtypes.AppendLine($"\t\t\t}}");

                csSubtypes.AppendLine($"\t\t\tConversionAnalytics.Instance.AddConverted(tableName, current.GLOBALID, name); ");

                csSubtypes.AppendLine($"\t\t\tLogger.Current.DataObject(objectid, tableName, longname, System.Text.Json.JsonSerializer.Serialize(instance)); ");

                //csSubtypes.AppendLine($"\t\t\tconvertedCount++;");


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
        public void ListDomainValues() {
            var sourcePath = @$"{Environment.GetEnvironmentVariable("OneDrive")}\ArcGIS\Projects\Vortex\replica.gdb";
            var source = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(sourcePath))));

            StringBuilder csDomainValues = new StringBuilder();

            var featureClass = source.OpenDataset<FeatureClass>("CoastlineL");
            var fieldName = "CATSLC";

            var field = featureClass.GetDefinition().GetFields().FirstOrDefault<Field>(e => e.Name.ToLower() == fieldName.ToLower());

            var sortedDict = (field.GetDomain(null) as CodedValueDomain).GetCodedValuePairs();
            csDomainValues.AppendLine($"/*");
            csDomainValues.AppendLine($"{field.GetDomain(null).GetName()}");
            foreach (var keyValuePair in sortedDict) {
                csDomainValues.AppendLine($"\t\t\t{keyValuePair.Key}: {keyValuePair.Value}");

            }
            csDomainValues.AppendLine($"*/");

            Console.WriteLine(csDomainValues.ToString());
        }

        [Fact]
        public void CreateS57Domains() {

        }

        [Fact]
        public void GenerateStatusPage() {
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

            featureclasses.Sort();

            //var sourcePath = @$"{Environment.GetEnvironmentVariable("OneDrive")}\ArcGIS\Projects\Vortex\replica.gdb";
            //var source = new Geodatabase(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(sourcePath))));
            var sourcePath = IO.Path.GetFullPath(IO.Path.Combine(@"G:\indigo\Databases\nis.sde"));
            var source = new Geodatabase(new DatabaseConnectionFile(new Uri(IO.Path.GetFullPath(sourcePath))));

            var prefix = "NIS.";

            string filePath = IO.Path.GetFullPath(IO.Path.Combine(@".\..\..\..\..\..\..\status_tt.txt"));

            StringBuilder content = new StringBuilder();

            List<Dataset> datasets = [];
            foreach (var featureclass in featureclasses) {
                datasets.Add(source.OpenDataset<FeatureClass>($"{prefix}{featureclass}"));
            }

            int counter = 0;
            using (StreamWriter file = new StreamWriter(filePath)) {
                foreach (var dataset in datasets) {
                    if (dataset is FeatureClass) {
                        var featureclass = (FeatureClass)dataset;
                        var subtypes = featureclass.GetDefinition().GetSubtypes();
                        var fields = featureclass.GetDefinition().GetFields();
                        var fieldHasData = new Dictionary<string, bool>();
                        var fieldAlias = new Dictionary<string, string>();

                        foreach (var field in fields) {
                            fieldHasData[field.Name] = false;
                            fieldAlias[field.Name] = field.AliasName;
                        }

                        var sortedDict = new SortedDictionary<int, string>();

                        var searchCursor = (dataset as FeatureClass)?.Search(new QueryFilter() { WhereClause = "1=1" });
                        if (searchCursor == null) {
                            throw new NotSupportedException("dataset is not a featureclass");
                        }

                        var subtypeCount = new Dictionary<int, int>();

                        int totalCount = 0;
                        while (searchCursor.MoveNext()) {
                            totalCount++;
                            var current = searchCursor.Current;

                            if (current.FindField("fcsubtype") == -1)
                                continue;

                            foreach (var fieldName in fieldHasData.Keys) {
                                if (DBNull.Value != current[fieldName] && current[fieldName] != null && !string.IsNullOrEmpty(current[fieldName].ToString())) {
                                    fieldHasData[fieldName] = true;
                                }
                            }

                            var subtypeValue = current["fcsubtype"];
                            if (subtypeValue != DBNull.Value) {
                                int subtype = Convert.ToInt32(subtypeValue);
                                if (subtypeCount.ContainsKey(subtype)) {
                                    subtypeCount[subtype] += 1;
                                }
                                else {
                                    subtypeCount[subtype] = 1;
                                }
                            }
                        }

                        foreach (var subtype in subtypes) {
                            sortedDict.Add(subtype.GetCode(), subtype.GetName());
                        }

                        foreach (var keyValuePair in sortedDict) {
                            counter += 1;

                            subtypeCount.TryGetValue(keyValuePair.Key, out var subtypeCountN);

                            content.AppendLine($"{counter};SUBTYPE;{dataset.GetName()};{keyValuePair.Value};{keyValuePair.Key};{subtypeCountN}");
                        }

                        foreach (var fieldName in fieldHasData.Keys) {
                            counter += 1;
                            var hasDataTag = fieldHasData[fieldName] ? "CONTAINS DATA" : "EMPTY";
                            content.AppendLine($"{counter};FIELD;{dataset.GetName()};{fieldName};{fieldAlias[fieldName]};{hasDataTag}");

                        }
                    }
                }
                file.WriteLine(content.ToString());
            }
        }

        [Fact]
        public void TestRelation() {
            //var relation1 = new Relation(new(typeof(SpecialPurposeGeneralBeacon), "S1"), new(typeof(LightAirObstruction), "S2"));
            //var relation2 = new Relation(new(typeof(SpecialPurposeGeneralBeacon), "S1"), new(typeof(LightAirObstruction), "S2"));

            //var relations = new HashSet<Relation>();

            //Assert.True(relation1.Equals(relation2));

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

            string filePath = IO.Path.GetFullPath(IO.Path.Combine(@".\..\..\..\..\..\..\..\src\Application\VortexLoader\S-57.esri\S57EsriAuto.cs"));
            StringBuilder csFile = new StringBuilder();

            List<Dataset> datasets = [];
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
                csFile.AppendLine("namespace S100Framework.Applications.S57auto.esri");
                csFile.AppendLine("{");

                foreach (var dataset in datasets) {
                    var datasetName = dataset.GetName();
                    StringBuilder fields = new StringBuilder();
                    StringBuilder ctor = new StringBuilder();
                    StringBuilder objectClass = new StringBuilder();

                    objectClass.AppendLine($"\tinternal class {dataset.GetName()} : S100Framework.Applications.S57.esri.S57Object {{");


                    IReadOnlyList<ArcGIS.Core.Data.Field> datasetfields = [];

                    if (dataset is FeatureClass) {
                        datasetfields = ((FeatureClass)dataset).GetDefinition().GetFields();
                        ctor.AppendLine($"\t\tpublic {dataset.GetName()}(Feature feature) {{");
                    }
                    else if (dataset is Table) {
                        datasetfields = ((Table)dataset).GetDefinition().GetFields();
                        ctor.AppendLine($"\t\tpublic {dataset.GetName()}(Row row) {{");
                    }

                    ctor.AppendLine($"\t\t\tbase.TableName = \"{datasetName}\";");

                    var fieldInfo = (Type: "Int32", Conversion: "Convert.ToInt32", DefaultValue: "default", Alias: string.Empty);

                    foreach (var field in datasetfields) {
                        if (field.Name.ToUpper().StartsWith("SHAPE_")) {
                            Console.WriteLine("");
                            continue;
                        }

                        fieldInfo = field.FieldType switch {
                            (FieldType)esriFieldType.esriFieldTypeBigInteger => (Type: "internal long?", Conversion: "Convert.ToLong", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeInteger => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeString => (Type: "internal string?", Conversion: "Convert.ToString", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeSmallInteger => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", Alias: field.AliasName),
                            //(FieldType)esriFieldType.esriFieldTypeDouble => (Type: "internal decimal?", Conversion: "Convert.ToDecimal", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeDouble => (Type: "internal double?", Conversion: "Convert.ToDouble", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeSingle => (Type: "internal int?", Conversion: "Convert.ToInt32", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeDate => (Type: "internal DateTime?", Conversion: "Convert.ToDateTime", Default: "default", Alias: field.AliasName),
                            (FieldType)esriFieldType.esriFieldTypeGUID => (Type: "internal Guid", Conversion: "Guid.Parse", Default: "Guid.Empty", Alias: field.AliasName),
                            //(FieldType)esriFieldType.esriFieldTypeBlob => (S101Type: "byte[]", Conversion: "", Default: "new byte[fs.Length]", field.AliasName),
                            //(FieldType)esriFieldType.esriFieldTypeRaster => (S101Type: "Raster", Conversion: "", Default: "default", field.AliasName),
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
                            if (field.Name.ToUpper() == "VALIDATIONSTATUS") {
                                ctor.AppendLine($"\t\t\tif (feature.FindField(\"VALIDATIONSTATUS\") > -1) {{ // NOAA Exception");
                                ctor.AppendLine($"\t\t\t\t\tif (DBNull.Value != feature[\"{field.Name.ToUpper()}\"] && feature[\"{field.Name.ToUpper()}\"] is not null) {{");
                            }
                            else {
                                ctor.AppendLine($"\t\t\tif (DBNull.Value != feature[\"{field.Name.ToUpper()}\"] && feature[\"{field.Name.ToUpper()}\"] is not null) {{");
                            }
                        }
                        else if (dataset is Table) {
                            ctor.AppendLine($"\t\t\tif (DBNull.Value != row[\"{field.Name.ToUpper()}\"] && row[\"{field.Name.ToUpper()}\"] is not null) {{");
                        }

                        if (fieldInfo.Type.ToLower().Contains("guid")) {
                            ctor.AppendLine($"\t\t\t\t{fieldValue};");
                            if (field.Name.ToUpper() == "GLOBALID") {
                                ctor.AppendLine($"\t\t\t\tbase.GlobalId = this.GLOBALID;");
                            }
                        }
                        else {
                            ctor.AppendLine($"\t\t\t\t{field.Name.ToUpper()} = {fieldValue};");
                            if (field.Name.ToUpper() == "VALIDATIONSTATUS") {
                                ctor.AppendLine($"\t\t\t\t}}");
                            }
                            if (field.Name.ToUpper() == "SHAPE") {
                                ctor.AppendLine($"\t\t\t\tbase.Shape = this.SHAPE;");
                            }
                            if (field.Name.ToUpper() == "PLTS_COMP_SCALE") {
                                ctor.AppendLine($"\t\t\t\tbase.PLTS_COMP_SCALE = this.PLTS_COMP_SCALE.Value;");
                            }
                            if (field.Name.ToUpper() == "SCAMIN_STEP") {
                                ctor.AppendLine($"\t\t\t\tbase.SCAMIN_STEP = this.SCAMIN_STEP.Value;");
                            }
                            if (field.Name.ToUpper() == "FCSUBTYPE") {
                                ctor.AppendLine($"\t\t\t\tbase.FcSubtype = this.FCSUBTYPE.Value;");
                            }
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
            var root = new IO.DirectoryInfo(@"e:\ArcGIS\Projects\NOAA\05CGD_ENCs\ENC_ROOT");

            var python = new StringBuilder();

            var filter = "US4";
            foreach (var enc in root.EnumerateDirectories()) {
                if (enc.Name.Contains("cancel", StringComparison.InvariantCultureIgnoreCase)) continue;
                if (!enc.Name.Contains(filter)) continue;

                var command = ImportS57ToGeodatabase(enc, "geodatabase.gdb", (e) => true);

                python.AppendLine(command);
            }

            this._output.WriteLine(python.ToString());
        }

        private static string ImportS57ToGeodatabase(DirectoryInfo folder, string connection, Func<string, bool> include) {
            var tasks = new List<string>();

            var regex = new Regex(@"\d{3}$");

            if (!folder.GetFiles("*.000", SearchOption.TopDirectoryOnly).Any()) {
                folder = folder.GetDirectories().OrderByDescending(e => e.Name).First();
            }

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

using JsonFlatten;
using Newtonsoft.Json.Linq;
using S100Framework.DomainModel.S101.FeatureTypes;
using S100Framework.DomainModel.S101.InformationTypes;
using System.Collections;
using System.Text;
using System.Text.Json;
using Xunit.Abstractions;


namespace TestS100Framework
{
    public class UnitTestYAML
    {
        private readonly ITestOutputHelper output;

        private static readonly JsonSerializerOptions jsonSerializerOptions = new() {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true,
        };

        public UnitTestYAML(ITestOutputHelper output) {
            this.output = output;

            //ArcGIS.Core.Hosting.Host.Initialize();
        }

        [Fact]
        public void Test_Serialize_LightAllAround() {
            var lightAllAround = new LightAllAround {
                colour = new List<S100Framework.DomainModel.S101.colour> {
                    S100Framework.DomainModel.S101.colour.Red,
                    S100Framework.DomainModel.S101.colour.White,
                },
                featureName = new List<S100Framework.DomainModel.S101.ComplexAttributes.featureName> {
                    new() {
                        language = "eng",
                        name = "Light E",
                    },
                },
                height = 54,
                rhythmOfLight = new S100Framework.DomainModel.S101.ComplexAttributes.rhythmOfLight {
                    lightCharacteristic = S100Framework.DomainModel.S101.lightCharacteristic.ContinuousUltraQuickFlashing,
                    signalGroup = new List<string> {
                        "6",
                    },
                    signalPeriod = 5,
                },
                valueOfNominalRange = 9,
            };

            var yaml = S100Framework.YAML.Converter.Serialize(lightAllAround);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_Serialize_RequiredAttribute() {
            var qualityOfBathymetricData = new QualityOfBathymetricData {
                categoryOfTemporalVariation = null,
                dataAssessment = null,
                featuresDetected = null,
                fullSeafloorCoverageAchieved = null,
            };

            var yaml = S100Framework.YAML.Converter.Serialize(qualityOfBathymetricData);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_Serialize_ServiceHours() {
            var serviceHours = new ServiceHours {
                scheduleByDayOfWeek = [new S100Framework.DomainModel.S101.ComplexAttributes.scheduleByDayOfWeek {
                    timeIntervalsByDayOfWeek = [new S100Framework.DomainModel.S101.ComplexAttributes.timeIntervalsByDayOfWeek {                        
                    }],
                }],
            };

            var json = System.Text.Json.JsonSerializer.Serialize(serviceHours);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_Deserialize_Feature() {
            var yamlDataset = @"CellName: 101DK40349E.000
Comment: Not for navigation!
Edition: 1
encver: INT.IHO.S-101.2.0
FCVer: 2.0.0
Metadata:
    OrganisationName: Geodatastyrelsen
    City: Aalborg
    AdministrativeArea: Denmark
    ElectronicMailAddress: jesoe @gst.dk
    Country: Denmark
    Producer: GST
    ProducerCode: DK00
InformationTypes:
  - Name: SpatialQuality
    ID: I2516971
    Attributes:
      - Name: qualityOfHorizontalMeasurement
        Value: 4
Points:
  - Name: P4155-0
    Location: 12.2888300,55.0000000
  - Name: P4155-1
    Location: 12.2897500,54.9875600
  - Name: P287-0
    Location: 12.0463744,54.8916438
Curves:
  - Name: C1804
    Start: P1804-0
    End: P1804-1
    Vertices: 12.0805300,54.9158500,12.0808300,54.9159100,12.0812300,54.9159400,12.0813900,54.9160000,12.0814900,54.9160900,12.0814800,54.9162500,12.0816600,54.9163500,12.0818300,54.9165100,12.0818900,54.9166600,12.0818300,54.9167100,12.0818200,54.9167600,12.0819600,54.9169100,12.0819200,54.9170300,12.0821700,54.9171700,12.0821300,54.9172300,12.0819800,54.9172800,12.0819800,54.9173500,12.0820900,54.9174200,12.0824200,54.9175100,12.0827100,54.9176500,12.0827400,54.9176900,12.0826200,54.9177100,12.0825300,54.9177500,12.0825500,54.9178100,12.0829400,54.9178900,12.0830900,54.9179400,12.0833500,54.9181600,12.0833300,54.9182800,12.0833700,54.9183400,12.0839600,54.9187600,12.0845100,54.9191000,12.0846900,54.9193900,12.0849300,54.9196800,12.0849200,54.9197200,12.0848000,54.9198000,12.0849200,54.9198900,12.0854900,54.9202000,12.0855100,54.9202400,12.0854400,54.9203100,12.0854600,54.9203600,12.0859200,54.9205000,12.0861000,54.9205900,12.0860500,54.9207100,12.0863000,54.9209400,12.0862400,54.9210400,12.0862900,54.9211300,12.0864600,54.9212100,12.0869700,54.9215300,12.0870300,54.9217000,12.0872100,54.9219500,12.0870700,54.9222400,12.0870700,54.9222900,12.0872700,54.9224300,12.0872900,54.9225100,12.0872200,54.9225700,12.0873500,54.9226600,12.0873400,54.9227100,12.0872800,54.9227300,12.0873600,54.9229000,12.0873100,54.9229500,12.0871700,54.9230000,12.0871100,54.9231500,12.0873600,54.9232300,12.0870800,54.9232600,12.0868700,54.9233500,12.0868500,54.9233900,12.0869200,54.9234600,12.0868800,54.9236500,12.0869700,54.9237700,12.0869600,54.9239500,12.0868700,54.9240200,12.0869100,54.9241200,12.0868400,54.9241900,12.0869100,54.9243200,12.0868700,54.9244300,12.0869700,54.9246500,12.0868200,54.9248700,12.0868800,54.9250300,12.0868900,54.9252600,12.0868500,54.9253500,12.0866700,54.9255400,12.0868200,54.9256900,12.0868600,54.9258000,12.0869100,54.9258300,12.0871000,54.9258800,12.0873600,54.9259100,12.0873700,54.9259100,12.0875200,54.9259200,12.0875900,54.9259300,12.0877500,54.9259800,12.0878800,54.9261300,12.0881300,54.9262700,12.0880400,54.9263400,12.0876700,54.9265000,12.0872700,54.9265000,12.0871400,54.9264800,12.0870800,54.9265500,12.0868100,54.9265800,12.0866100,54.9267300,12.0861900,54.9266800,12.0859600,54.9266200,12.0858600,54.9266400,12.0857500,54.9267000,12.0856200,54.9267200,12.0854600,54.9268700,12.0853500,54.9271400,12.0852800,54.9273000,12.0852800,54.9274300,12.0852000,54.9274600,12.0850600,54.9274800,12.0850600,54.9275200,12.0851700,54.9276200,12.0851300,54.9276700,12.0851900,54.9277300,12.0853700,54.9278000,12.0859000,54.9279000,12.0859700,54.9280100,12.0864200,54.9282100,12.0864300,54.9282500,12.0863000,54.9283200,12.0860800,54.9283300,12.0856800,54.9282700,12.0854300,54.9282000,12.0852700,54.9282000,12.0852100,54.9282400,12.0852500,54.9283300,12.0852000,54.9283600,12.0849300,54.9284300,12.0848913,54.9284466,12.0847200,54.9285200,12.0839100,54.9286400,12.0838100,54.9287300,12.0835400,54.9287800,12.0833900,54.9288600,12.0831100,54.9289300,12.0830200,54.9290000,12.0829900,54.9290600,12.0828700,54.9291200,12.0823700,54.9292500,12.0820800,54.9294000,12.0819200,54.9294600,12.0815600,54.9295200,12.0807000,54.9295400,12.0804100,54.9296800,12.0797700,54.9297800,12.0796500,54.9298300,12.0795400,54.9299100,12.0794000,54.9299100,12.0792600,54.9299500,12.0792000,54.9300800,12.0789600,54.9302200,12.0787900,54.9304200,12.0787700,54.9305000,12.0789000,54.9306100,12.0789100,54.9306800,12.0786700,54.9310300,12.0783800,54.9311600,12.0783300,54.9313100,12.0782700,54.9313600,12.0777700,54.9314500,12.0774500,54.9316200,12.0771600,54.9317500,12.0769400,54.9317900,12.0767700,54.9318600
  - Name: C230
    Start: P230-0
    End: P230-1
    Vertices: 12.1742374,54.8686737,12.1733618,54.8690668,12.1733100,54.8690900,12.1728700,54.8692300,12.1716000,54.8695800,12.1710400,54.8697100,12.1705000,54.8698000,12.1697482,54.8698814,12.1681000,54.8700600,12.1675100,54.8702100,12.1672400,54.8703400,12.1670200,54.8704900,12.1664200,54.8710200,12.1660500,54.8712100,12.1658300,54.8712900,12.1649500,54.8715400,12.1643700,54.8717500,12.1634999,54.8722231,12.1633400,54.8723100,12.1628958,54.8724494,12.1624800,54.8725800,12.1622206,54.8727025,12.1621200,54.8727500,12.1618700,54.8729700,12.1617900,54.8730400,12.1614200,54.8733100,12.1612465,54.8733892,12.1609600,54.8735200,12.1604629,54.8736302,12.1601169,54.8737160,12.1588565,54.8741332,12.1579742,54.8745039,12.1577385,54.8745905,12.1568273,54.8749254,12.1561467,54.8752089,12.1552266,54.8754850,12.1546090,54.8756013,12.1544048,54.8756313,12.1541826,54.8756639,12.1539158,54.8757031,12.1537491,54.8757292,12.1535918,54.8757571,12.1534439,54.8757868,12.1532054,54.8758342,12.1530878,54.8758586,12.1528565,54.8759481,12.1527380,54.8760069,12.1526274,54.8760560,12.1525117,54.8761103,12.1523912,54.8761697,12.1522657,54.8762343,12.1521353,54.8763041,12.1520000,54.8763790,12.1513013,54.8766991,12.1510799,54.8768005,12.1509268,54.8768478,12.1504736,54.8769877,12.1500118,54.8772259,12.1496524,54.8774113,12.1492321,54.8776282,12.1490578,54.8777040,12.1486251,54.8778923,12.1474673,54.8783741,12.1459036,54.8790279,12.1445070,54.8795716,12.1432951,54.8800137,12.1432203,54.8800410,12.1423012,54.8804195,12.1416566,54.8809563,12.1412236,54.8813493,12.1411076,54.8814546,12.1400691,54.8824731,12.1393171,54.8832824,12.1385532,54.8841013,12.1383716,54.8843002,12.1381703,54.8845080,12.1379495,54.8847246,12.1377092,54.8849500,12.1374492,54.8851843,12.1371707,54.8854267,12.1368944,54.8856629,12.1366290,54.8858867,12.1363744,54.8860983,12.1361306,54.8862975,12.1358976,54.8864846,12.1356746,54.8866601,12.1354561,54.8868295,12.1352412,54.8869934,12.1350299,54.8871518,12.1348222,54.8873049,12.1346182,54.8874526,12.1344163,54.8875943,12.1342131,54.8877286,12.1340302,54.8878421,12.1340085,54.8878555,12.1338025,54.8879749,12.1335950,54.8880870,12.1333861,54.8881916,12.1320773,54.8886031,12.1319253,54.8886718,12.1318247,54.8887755,12.1317552,54.8888884,12.1315745,54.8890048,12.1314151,54.8891253,12.1313025,54.8892512,12.1312666,54.8893694,12.1312256,54.8894679,12.1311744,54.8895319,12.1311368,54.8895762,12.1311036,54.8896054,12.1310717,54.8896429,12.1310428,54.8896814,12.1310170,54.8897209,12.1309938,54.8897603,12.1309717,54.8897974,12.1309507,54.8898321,12.1309306,54.8898645,12.1309117,54.8898944,12.1308936,54.8899237,12.1308761,54.8899535,12.1308595,54.8899837,12.1308433,54.8900145,12.1308273,54.8900460,12.1308058,54.8900792,12.1308035,54.8900819,12.1308000,54.8900863,12.1307733,54.8901157,12.1307462,54.8901329,12.1306764,54.8901592,12.1306181,54.8901797,12.1305184,54.8902068,12.1303817,54.8902462,12.1302247,54.8903003,12.1302085,54.8903080,12.1289150,54.8909251,12.1275150,54.8911854,12.1263408,54.8914197,12.1255730,54.8916800,12.1247149,54.8925650,12.1235407,54.8932158,12.1223213,54.8936063,12.1207858,54.8941789,12.1183019,54.8946995,12.1173535,54.8950640,12.1149599,54.8955898,12.1113469,54.8965528,12.1103985,54.8968131,12.1086824,54.8972296,12.1078694,54.8977501,12.1058823,54.8984529,12.1032629,54.8989214,12.1010951,54.8990515,12.0994241,54.8992857,12.0975763,54.8997481,12.0959918,54.9001446,12.0944983,54.9007184,12.0928756,54.9013418,12.0889563,54.9020986,12.0880532,54.9023438,12.0872758,54.9025617,12.0866241,54.9027522,12.0860981,54.9029153,12.0855678,54.9030688,12.0848924,54.9032319,12.0840717,54.9034047,12.0831057,54.9035872,12.0820368,54.9037705,12.0809147,54.9039441,12.0797396,54.9041081,12.0785114,54.9042624,12.0776025,54.9043638,12.0773297,54.9043943,12.0763207,54.9044876,12.0754850,54.9045423,12.0748224,54.9045583,12.0742908,54.9045506,12.0738321,54.9045396,12.0734461,54.9045253,12.0731327,54.9045078,12.0728683,54.9044949,12.0726182,54.9044980,12.0723821,54.9045171,12.0721600,54.9045524,12.0719261,54.9046007,12.0716396,54.9046571,12.0713001,54.9047215,12.0709074,54.9047940,12.0704687,54.9048770,12.0699956,54.9049750,12.0696734,54.9050468,12.0694885,54.9050880,12.0689473,54.9052160,12.0683837,54.9053507,12.0678191,54.9054769,12.0672539,54.9055943,12.0666882,54.9057029,12.0661354,54.9058002,12.0656222,54.9058814,12.0651491,54.9059464,12.0647164,54.9059951,12.0643213,54.9060247,12.0639585,54.9060290,12.0636280,54.9060078,12.0633296,54.9059611,12.0630862,54.9058889,12.0629495,54.9057912,12.0629214,54.9056680,12.0630019,54.9055193,12.0631501,54.9053543,12.0632665,54.9051953,12.0633467,54.9050432,12.0633907,54.9048980,12.0633985,54.9047505,12.0633701,54.9045765,12.0633055,54.9043746,12.0632046,54.9041449,12.0630808,54.9038967,12.0629709,54.9036563,12.0628771,54.9034252,12.0627994,54.9032033,12.0627511,54.9029929,12.0627726,54.9028006,12.0628665,54.9026268,12.0630328,54.9024716,12.0632634,54.9023292,12.0635322,54.9021813,12.0638372,54.9020264,12.0641784,54.9018645,12.0645321,54.9016996,12.0648163,54.9015452,12.0650241,54.9014023,12.0651555,54.9012710,12.0652128,54.9011523,12.0652048,54.9010494,12.0651325,54.9009628,12.0649959,54.9008923,12.0647963,54.9008399,12.0645398,54.9008122,12.0642270,54.9008100,12.0638579,54.9008333,12.0634470,54.9008718,12.0630571,54.9008806,12.0626953,54.9008546,12.0623617,54.9007939,12.0620530,54.9007050,12.0617542,54.9006192,12.0614635,54.9005404,12.0611809,54.9004685,12.0609039,54.9004025,12.0606205,54.9003373,12.0603291,54.9002721,12.0600296,54.9002068,12.0597259,54.9001482,12.0594392,54.9001329,12.0591726,54.9001662,12.0589262,54.9002483,12.0586952,54.9003707,12.0584526,54.9004849,12.0581939,54.9005829,12.0579192,54.9006646,12.0576240,54.9007304,12.0572814,54.9007820,12.0568865,54.9008197,12.0564393,54.9008434,12.0559497,54.9008530,12.0554870,54.9008466,12.0550646,54.9008241,12.0546824,54.9007854,12.0543392,54.9007308,12.0540261,54.9006640,12.0537411,54.9005855,12.0534843,54.9004955,12.0532532,54.9003974,12.0530267,54.9003205,12.0528003,54.9002714,12.0525739,54.9002502,12.0523484,54.9002571,12.0521328,54.9002957,12.0519293,54.9003667,12.0517378,54.9004702,12.0515561,54.9006030,12.0513605,54.9007326,12.0511447,54.9008506,12.0509089,54.9009570,12.0506495,54.9010515,12.0503285,54.9011308,12.0499350,54.9011938,12.0494691,54.9012406,12.0489280,54.9012727,12.0482767,54.9013084,12.0475048,54.9013535,12.0466122,54.9014077,12.0456026,54.9014714,12.0445279,54.9015461,12.0434049,54.9016325,12.0422337,54.9017304,12.0410170,54.9018404,12.0398005,54.9019708,12.0386001,54.9021243,12.0374159,54.9023010,12.0362400,54.9025031,12.0349315,54.9027713,12.0334381,54.9031205,12.0317595,54.9035509,12.0299071,54.9040593,12.0281141,54.9045804,12.0264740,54.9050880,12.0249868,54.9055822,12.0236447,54.9060649,12.0222589,54.9065844,12.0207484,54.9071614,12.0191132,54.9077958,12.0173620,54.9084851,12.0157450,54.9091536,12.0143775,54.9097664,12.0132593,54.9103236,12.0123858,54.9108274,12.0115904,54.9113555,12.0107910,54.9119461,12.0099876,54.9125993,12.0091795,54.9133149,12.0083355,54.9140869,12.0074392,54.9149123,12.0064906,54.9157909,12.0054886,54.9167244,12.0043723,54.9177974,12.0031072,54.9190580,12.0016932,54.9205064,12.0001343,54.9221378,12.0000000,54.9222788
CompositeCurves:
  - Name: C2058
    Components: C618,RC159,C619
  - Name: C2294
    Components: C1744,C406,C1743
Depths:
  - Name: P1293974
    Location: 12.0000400,54.9524800
    Z: 0.8
  - Name: P1293975
    Location: 12.0002172,54.5004301
    Z: 10.7
Surfaces:
  - Name: S4965
    Exterior: C2913
    Interior:
      - Hole: C2914
  - Name: S4651
    Exterior: C4647
    Interior:
      - Hole: RC1552
      - Hole: RC1925
  - Name: S4964
    Exterior: C2912
Features:
  - Name: Bridge
    Prim: Surface
    Foid: 110:5163:1
    Attributes:
      - Name: featureName
        id: 1
      - Name: language
        Value: eng
        parent: 1
      - Name: name
        Value: Dronning Alexandrines Bro
        parent: 1
      - Name: nameUsage
        Value: 1
        parent: 1
      - Name: openingBridge
        Value: 0
    Geometry: S5163
  - Name: Sounding
    Prim: Point
    Foid: 110:1057970:1
    Attributes:
      - Name: scaleMinimum
        Value: 89999
    Geometry: P1057970
  - Name: RestrictedArea
    Prim: Surface
    Foid: 110:5207:1
    Attributes:
      - Name: categoryOfRestrictedArea
        Value: 4
      - Name: categoryOfRestrictedArea
        Value: 5
      - Name: featureName
        id: 1
      - Name: language
        Value: eng
        parent: 1
      - Name: name
        Value: Uvlshale Nyord
        parent: 1
      - Name: nameUsage
        Value: 1
        parent: 1
      - Name: restriction
        Value: 27
      - Name: scaleMinimum
        Value: 89999
      - Name: information
        id: 2
      - Name: language
        Value: eng
        parent: 2
      - Name: text
        Value: Speed limit is 8 knots outside the channel
        parent: 2
    Geometry: S5207";

            // overwrite with full yaml dataset
            var fullDatasetPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"101DK40349E.yaml");
            if (System.IO.File.Exists(fullDatasetPath))
                yamlDataset = System.IO.File.ReadAllText(fullDatasetPath);

            var deserialized = S100Framework.YAML.Converter.Deserialize<S100Framework.YAML.Dataset>(yamlDataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_101DKLALAL() {
            var fullDatasetPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), $"101DKLALAL.yaml");
            var yamlDataset = System.IO.File.ReadAllText(fullDatasetPath);

            var deserialized = S100Framework.YAML.Converter.Deserialize<S100Framework.YAML.Dataset>(yamlDataset);

            System.Diagnostics.Debugger.Break();
        }


        [Fact]
        public void Test_Dataset() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_DatasetPoint() {
            var p1101 = new S100Framework.YAML.Point(-32.1333332, 62.5) {
                Name = "P1101",
            };

            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            }.AddPoint(p1101);

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_DatasetCurve() {
            var p1101 = new S100Framework.YAML.Point(-32.1333332, 62.5) {
                Name = "P1101",
            };

            var c1201 = new S100Framework.YAML.Curve(p1101.Name, new S100Framework.YAML.Coordinate[]{
                        new(-32.1333332,62.5),
                        new(-31.9666666,62.5),
                        new(-31.9666666,62.6666666),
                        new(-32.1333332,62.6666666),
                        new(-32.1333332,62.5),
                    }) {
                Name = "C1201",
            };

            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            }.AddPoint(p1101).AddCurve(c1201);

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_DatasetSurface() {
            var p1101 = new S100Framework.YAML.Point(-32.1333332, 62.5) {
                Name = "P1101",
            };

            var c1201 = new S100Framework.YAML.Curve(p1101.Name, [
                        new S100Framework.YAML.Coordinate(-32.1333332,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.6666666),
                        new S100Framework.YAML.Coordinate(-32.1333332,62.6666666),
                        new S100Framework.YAML.Coordinate(-32.1333332,62.5),
                    ]) {
                Name = "C1201",
            };

            var c12010 = new S100Framework.YAML.Curve([
                        new S100Framework.YAML.Coordinate(-32.1333332,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.6666666),
                    ]) {
                Name = "C12010",
            };

            var c12011 = new S100Framework.YAML.Curve([
                        new S100Framework.YAML.Coordinate(-32.1333332,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.5),
                        new S100Framework.YAML.Coordinate(-31.9666666,62.6666666),
                    ]) {
                Name = "C12011",
            };

            var s1301 = new S100Framework.YAML.Surface(c1201.Vertices!) {
                Name = "S1301",
                InteriorRings = [
                    c12010.Vertices!, c12011.Vertices!
                    ],
            };

            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            }
            .AddPoint(p1101)
            .AddCurve(c1201).AddCurve(c12010).AddCurve(c12011)
            .AddSurface(s1301);


            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_DataCoverage() {
            var dataCoverage = new DataCoverage {
                maximumDisplayScale = 22000,
                minimumDisplayScale = 180000,
                optimumDisplayScale = 45000,
            };

            var yaml = S100Framework.YAML.Converter.Serialize(dataCoverage);


            var lightAllAround = new LightAllAround {
                colour = new List<S100Framework.DomainModel.S101.colour> {
                    S100Framework.DomainModel.S101.colour.Red,
                    S100Framework.DomainModel.S101.colour.White,
                },
                featureName = new List<S100Framework.DomainModel.S101.ComplexAttributes.featureName> {
                    new() {
                        language = "eng",
                        name = "Light E",
                    },
                },
                height = 54,
                rhythmOfLight = new S100Framework.DomainModel.S101.ComplexAttributes.rhythmOfLight {
                    lightCharacteristic = S100Framework.DomainModel.S101.lightCharacteristic.ContinuousUltraQuickFlashing,
                    signalGroup = new List<string> {
                        "6",
                    },
                    signalPeriod = 5,
                },
                valueOfNominalRange = 9,
            };

            {
                output.WriteLine("--- Direct ----------------------------------------");

                var flatten = Implementation.Execute(lightAllAround);

                foreach (var e in flatten) {
                    output.WriteLine($"{e.Key}: {e.Value}");
                }
            }

            {
                output.WriteLine("--- JSON ------------------------------------------");

                var json = System.Text.Json.JsonSerializer.Serialize(lightAllAround, jsonSerializerOptions);
                var jsonObject = JObject.Parse(json);

                var flatten = jsonObject.Flatten(includeNullAndEmptyValues: false);

                foreach (var e in flatten) {
                    output.WriteLine($"{e.Key}: {e.Value}");
                }

                output.WriteLine("");

                output.WriteLine("Attributes:");
                foreach (var e in flatten) {
                    output.WriteLine($"\t- Name: {e.Key}");
                    output.WriteLine($"\t  Value: {e.Value}");
                }
            }
        }

        [Fact]
        public void Test_DatasetFeature() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var feature = new S100Framework.YAML.Feature() {
                Name = "QualityOfBathymetricData",
                Foid = "1810:3:2",
                Prim = S100Framework.YAML.Primitive.Surface,
                Attributes = new LightAllAround {
                    colour = new List<S100Framework.DomainModel.S101.colour> {
                        S100Framework.DomainModel.S101.colour.Red,
                        S100Framework.DomainModel.S101.colour.White,
                    },
                    exhibitionConditionOfLight = S100Framework.DomainModel.S101.exhibitionConditionOfLight.LightShownWithoutChangeOfCharacter,
                    featureName = new List<S100Framework.DomainModel.S101.ComplexAttributes.featureName> {
                        new() {
                            language = "eng",
                            name = "Light E",
                        },
                    },
                    height = 54,
                    rhythmOfLight = new S100Framework.DomainModel.S101.ComplexAttributes.rhythmOfLight {
                        lightCharacteristic = S100Framework.DomainModel.S101.lightCharacteristic.ContinuousUltraQuickFlashing,
                        signalGroup = new List<string> {
                        "6",
                    },
                        signalPeriod = 5,
                    },
                    valueOfNominalRange = 9,
                }
            };

            dataset.AddFeature(feature);

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }


        [Fact]
        public void Test_FeatureDecimal() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var feature = new S100Framework.YAML.Feature() {
                Name = "QualityOfBathymetricData",
                Foid = "1810:3:2",
                Prim = S100Framework.YAML.Primitive.Surface,
                Attributes = new SpecialPurposeGeneralBeacon {
                    beaconShape = default,
                    verticalLength = 4.5m
                }
            };

            dataset.AddFeature(feature);

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_DatasetInformationType() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var informationType = new S100Framework.YAML.Information() {
                Name = "SpatialQuality",
                ID = "I83413",
                Attributes = new S100Framework.DomainModel.S101.InformationTypes.SpatialQuality {
                    qualityOfHorizontalMeasurement = S100Framework.DomainModel.S101.qualityOfHorizontalMeasurement.Approximate,
                },
            };

            dataset.AddInformation(informationType);

            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }


        [Fact]
        public void Test_SerializeBridge() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var json = @"{""bridgeConstruction"":null,""bridgeFunction"":[],""categoryOfOpeningBridge"":null,""colour"":[],""colourPattern"":null,""condition"":null,""featureName"":[{""language"":""eng"",""name"":""Dronning Alexandrines Bro"",""nameUsage"":1}],""fixedDateRange"":null,""height"":null,""interoperabilityIdentifier"":null,""natureOfConstruction"":[],""openingBridge"":false,""radarConspicuous"":null,""reportedDate"":null,""status"":[],""visualProminence"":null,""scaleMinimum"":null,""information"":[],""pictorialRepresentation"":null}";

            var featureCatalogue = S100Framework.Catalogues.FeatureCatalogue.Catalogues.Single(e => e.ProductID.Equals("S-101"));
            var name = "Bridge";
            var geometry = "S874953";
            var foid = "110:874953:1";

            var type = featureCatalogue.Assembly!.GetType($"{S100Framework.Catalogues.FeatureCatalogue.Namespace("S101", "FeatureTypes")}.{name}", true) ?? default;


            var instance = System.Text.Json.JsonSerializer.Deserialize(json!, type!);

            var feature = new S100Framework.YAML.Feature {
                Name = name,
                Foid = foid,
                Prim = S100Framework.YAML.Primitive.Surface,
                Geometry = geometry,
                Attributes = (S100Framework.DomainModel.FeatureNode)instance!,
            };

            dataset.AddFeature(feature);


            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }

        [Fact]
        public void Test_FeatureWIthStaticProperties() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var feature = new S100Framework.YAML.Feature() {
                Name = "Coastline",
                Foid = "1810:3:2",
                Prim = S100Framework.YAML.Primitive.Surface,
                Attributes = new Coastline {
                    colour = new List<S100Framework.DomainModel.S101.colour> {
                        S100Framework.DomainModel.S101.colour.Red,
                        S100Framework.DomainModel.S101.colour.White,
                    },
                    featureName = new List<S100Framework.DomainModel.S101.ComplexAttributes.featureName> {
                        new() {
                            language = "eng",
                            name = "Light E",
                        },
                    },
                }
            };

            dataset.AddFeature(feature);


            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }



        [Fact]
        public void Test_DatasetFeatureAssociation() {
            var dataset = new S100Framework.YAML.Dataset {
                CellName = "101AA00DS0031.000",
                Comment = "S-101 Test Dataset 031",
                Edition = 1,
                FCVer = "2.0",
            };

            var informationType = new S100Framework.YAML.Information() {
                Name = "SpatialQuality",
                ID = "I83413",
                Attributes = new S100Framework.DomainModel.S101.InformationTypes.SpatialQuality {
                    qualityOfHorizontalMeasurement = S100Framework.DomainModel.S101.qualityOfHorizontalMeasurement.Approximate,
                },
            };

            var feature = new S100Framework.YAML.Feature() {
                Name = "QualityOfBathymetricData",
                Foid = "1810:3:2",
                Prim = S100Framework.YAML.Primitive.Surface,
                Attributes = new LightAllAround {
                    colour = new List<S100Framework.DomainModel.S101.colour> {
                    S100Framework.DomainModel.S101.colour.Red,
                    S100Framework.DomainModel.S101.colour.White,
                },
                    featureName = new List<S100Framework.DomainModel.S101.ComplexAttributes.featureName> {
                    new() {
                        language = "eng",
                        name = "Light E",
                    },
                },
                    height = 54,
                    rhythmOfLight = new S100Framework.DomainModel.S101.ComplexAttributes.rhythmOfLight {
                        lightCharacteristic = S100Framework.DomainModel.S101.lightCharacteristic.ContinuousUltraQuickFlashing,
                        signalGroup = new List<string> {
                        "6",
                    },
                        signalPeriod = 5,
                    },
                    valueOfNominalRange = 9,
                }
            };

            var association = new S100Framework.YAML.Association {
                To = "I83413",
                Name = "QualityOfBathymetricDataComposition",
                Role = "theQualityInformation"
            };

            var featureAssociation = new S100Framework.YAML.Association {
                To = "1810:3:2",
                Name = "StructureEquipment",
                Role = "theEquipment"
            };

            feature.AddAssociation(association);
            feature.AddFeatureAssociation(featureAssociation);
            dataset.AddInformation(informationType);
            dataset.AddFeature(feature);


            var yaml = S100Framework.YAML.Converter.Serialize(dataset);

            System.Diagnostics.Debugger.Break();
        }
    }
}

namespace TestS100Framework
{
    public static class Extension
    {
        public static string Attributes(this LightAllAround instance) {
            var b = new StringBuilder();


            return string.Empty;
        }

        internal static bool IsValueTypeOrString(this Type type) {
            return type.IsValueType || type == typeof(string);
        }

        internal static string ToStringValueType(this object value) {
            return value switch {
                DateTime dateTime => dateTime.ToString("o"),
                bool boolean => boolean.ToStringLowerCase(),
                _ => value.ToString()
            };
        }

        internal static bool IsIEnumerable(this Type type) {
            return type.IsAssignableTo(typeof(IEnumerable));
        }

        internal static string ToStringLowerCase(this bool boolean) {
            return boolean ? "true" : "false";
        }
    }
}

namespace TestS100Framework
{
    using System;
    using System.Collections;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    public interface IFlatDictionaryProvider
    {
        //Dictionary<string, string> Execute(object @object, string prefix = "");
    }

    public class Implementation : IFlatDictionaryProvider
    {
        private static readonly ConcurrentDictionary<Type, Dictionary<PropertyInfo, Func<object, object>>> CachedProperties;

        static Implementation() {
            CachedProperties = new ConcurrentDictionary<Type, Dictionary<PropertyInfo, Func<object, object>>>();
        }

        public static Dictionary<string, string> Execute(object @object, string prefix = "") {
            return ExecuteInternal(@object, prefix: prefix);
        }

        private static Dictionary<string, string> ExecuteInternal(
            object @object,
            Dictionary<string, string> dictionary = default,
            string prefix = "") {
            dictionary ??= new Dictionary<string, string>();
            var type = @object.GetType();
            var properties = GetProperties(type);

            foreach (var (property, getter) in properties) {
                var key = string.IsNullOrWhiteSpace(prefix) ? property.Name : $"{prefix}.{property.Name}";
                var value = getter(@object);

                if (value == null) {
                    dictionary.Add(key, null);
                    continue;
                }

                if (property.PropertyType.IsValueTypeOrString()) {
                    dictionary.Add(key, value.ToStringValueType());
                }
                else {
                    if (value is IEnumerable enumerable) {
                        var counter = 0;
                        foreach (var item in enumerable) {
                            var itemKey = $"{key}[{counter++}]";
                            var itemType = item.GetType();
                            if (itemType.IsValueTypeOrString()) {
                                dictionary.Add(itemKey, item.ToStringValueType());
                            }
                            else {
                                ExecuteInternal(item, dictionary, itemKey);
                            }
                        }
                    }
                    else {
                        ExecuteInternal(value, dictionary, key);
                    }
                }
            }

            return dictionary;
        }

        private static Dictionary<PropertyInfo, Func<object, object>> GetProperties(Type type) {
            if (CachedProperties.TryGetValue(type, out var properties)) {
                return properties;
            }

            CacheProperties(type);
            return CachedProperties[type];
        }

        private static void CacheProperties(Type type) {
            if (CachedProperties.ContainsKey(type)) {
                return;
            }

            CachedProperties[type] = new Dictionary<PropertyInfo, Func<object, object>>();
            var properties = type.GetProperties().Where(x => x.CanRead);
            foreach (var propertyInfo in properties) {
                var getter = CompilePropertyGetter(propertyInfo);
                CachedProperties[type].Add(propertyInfo, getter);
                if (!propertyInfo.PropertyType.IsValueTypeOrString()) {
                    if (propertyInfo.PropertyType.IsIEnumerable()) {
                        var types = propertyInfo.PropertyType.GetGenericArguments();
                        foreach (var genericType in types) {
                            if (!genericType.IsValueTypeOrString()) {
                                CacheProperties(genericType);
                            }
                        }
                    }
                    else {
                        CacheProperties(propertyInfo.PropertyType);
                    }
                }
            }
        }

        // Inspired by Zanid Haytam
        // https://blog.zhaytam.com/2020/11/17/expression-trees-property-getter/
        private static Func<object, object> CompilePropertyGetter(PropertyInfo property) {
            var objectType = typeof(object);
            var objectParameter = Expression.Parameter(objectType);
            var castExpression = Expression.TypeAs(objectParameter, property.DeclaringType);
            var convertExpression = Expression.Convert(
                Expression.Property(castExpression, property),
                objectType);
            return Expression.Lambda<Func<object, object>>(
                convertExpression,
                objectParameter).Compile();
        }
    }
}


/*
 * Samples

Attributes:
      - Name: colour
        Value: 3
      - Name: colour
        Value: 1
      - Name: rhythmOfLight
        id: 2
      - Name: lightCharacteristic
        parent: 2
        Value: 4
      - Name: signalGroup
        parent: 2
        Value: (2)
      - Name: signalPeriod
        parent: 2
        Value: 4
    Geometry: P110125
 



*/
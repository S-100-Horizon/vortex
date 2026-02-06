using S100FC.YAML;
using System.Text.Json;
using Xunit.Abstractions;

namespace TestS100FC
{
    public class UnitTestYAML(ITestOutputHelper output)
    {
        private readonly ITestOutputHelper output = output;


        [Fact]
        public void CompareDataset() {
            var latestPath = @"C:\\Geodatastyrelsen\\yamlupdatetest\latest.yaml";
            var incomingPath = @"C:\\Geodatastyrelsen\\yamlupdatetest\incoming.yaml";

            var latest = System.IO.File.ReadAllText(latestPath);
            var incoming = System.IO.File.ReadAllText(incomingPath);

            var delta = S100FC.YAML.DatasetComparer.Compare(latest, incoming);


            System.Diagnostics.Debugger.Break();

        }


        [Fact]
        public void Test_Build_Dataset_Update() {
            // Setup

            // Specify Dataset Name
            var DSNM = "101DK0040349E";

            // Specify the current edition
            var edition = 1;

            // Specify which update to create
            var update = 2; // 1 if first          

            // Specify the updates to append to the YAML Dataset
            string[] updates = ["001"];  // Empty if first    "002"
            //string[] updates = [];
            // Specify the incoming full YAML dataset
            var incomingDataset = System.IO.File.ReadAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "s100ed8", DSNM, "Incoming", $"{DSNM}_{update:D3}.yaml"));

            var rootPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "s100ed8", DSNM, $"{edition}", $"{DSNM}_000.yaml");
            var yamlRoot = System.IO.File.ReadAllText(rootPath);

            foreach (var upd in updates) {
                var updatePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "s100ed8", DSNM, $"{edition}", $"{DSNM}_{upd}.yaml");
                var yamlUpdateDelta = System.IO.File.ReadAllText(updatePath);

                yamlRoot = DatasetComparer.AppendUpdate(yamlRoot, yamlUpdateDelta);
            }

            // Compare the appended root dataset with the incoming update
            var datasetDiff = DatasetComparer.Compare(yamlRoot, incomingDataset);

            // Build and write new update delta
            var datasetDiffed = Converter.Serialize(datasetDiff);

            System.Diagnostics.Debugger.Break();
            // Create new update
            System.IO.File.WriteAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "s100ed8", DSNM, $"{edition}", $"{DSNM}_{update:D3}.yaml"), datasetDiffed);
        }

        [Fact]
        public void Test_Read_Dateset_Updates() {
            // Setup
            var DSNM = "101DK0040349E";

            // Specify the current edition
            var edition = 1;

            // Specify the updates to append to the YAML Dataset
            string[] updates = ["001"];  // Empty if first


            bool shouldCreate = true;

            var rootPath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "s100ed8", DSNM, $"{edition}", $"{DSNM}_000.yaml");
            var yamlRoot = System.IO.File.ReadAllText(rootPath);

            foreach (var upd in updates) {
                var updatePath = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "s100ed8", DSNM, $"{edition}", $"{DSNM}_{upd}.yaml");
                var yamlUpdateDelta = System.IO.File.ReadAllText(updatePath);

                yamlRoot = DatasetComparer.AppendUpdate(yamlRoot, yamlUpdateDelta);
            }

            if (shouldCreate)
                System.IO.File.WriteAllText(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "s100ed8", DSNM, "Outgoing", $"{DSNM}_full_{updates.LastOrDefault()}.yaml"), yamlRoot);

            System.Diagnostics.Debugger.Break();
        }
    }
}
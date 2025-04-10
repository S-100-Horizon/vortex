using ArcGIS.Desktop.Internal.Core;
using ArcGIS.Desktop.Internal.Mapping.PropertyPages;
using S100Framework.DomainModel.S131.Associations.FeatureAssociations;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Xml.Linq;
namespace S100Framework.Applications
{

    public enum PrimitiveType {
        Point=1,
        Line=2,
        Area=4
    }

    /*
    var objects = parser.GetObjects();
    foreach (var obj in objects) {
        Console.WriteLine($"\nObject Name: {obj.Name}");
        Console.WriteLine($"Primitive Type: {obj.PrimitiveType}");
        Console.WriteLine($"Has Condition: {obj.HasCondition}");
        Console.WriteLine($"Default Step Value: {obj.DefaultStepValue}");
        if (obj.Conditions.Any()) {
            Console.WriteLine("Conditions:");
            foreach (var condition in obj.Conditions) {
                Console.WriteLine("  - Rules: " + string.Join(", ", condition));
            }
        }
        else {
            Console.WriteLine("No conditions.");
        }
    }
    */

    public class ScaminDenmark : ScaminFile
    {
        private static ScaminDenmark _instance;
        private static readonly object _lock = new object();

        public string PathToScaminFile { get; private set; }

        private ScaminDenmark(string pathToScaminFiles) : base(@$"{pathToScaminFiles}\SCAMIN_GST_Danmark.xml") {
            PathToScaminFile = pathToScaminFiles;
        }


        public static ScaminDenmark Instance {
            get {
                if (_instance == null) {
                    {
                        lock (_lock) {
                            _instance = new ScaminDenmark(ImporterNIS._scaminFilesPath);
                        }
                    }
                }
                return _instance;
            }
        }

    }

    public class ScaminGreenland : ScaminFile
    {
        private static ScaminGreenland _instance;
        private static readonly object _lock = new object();

        public string PathToScaminFile { get; private set; }

        private ScaminGreenland(string pathToScaminFiles) : base(@$"{pathToScaminFiles}\SCAMIN_GST_Grønland.xml") {
            PathToScaminFile = pathToScaminFiles;
        }

        public static ScaminGreenland Instance {
            get {
                if (_instance == null) {
                    _instance = new ScaminGreenland(ImporterNIS._scaminFilesPath);
                }
                return _instance;
            }
        }

    }

    public abstract class ScaminFile
    {
        private XElement root;
        private List<int> _radarScales;
        private List<int> _scaminValues;

        internal ScaminFile(string filePath) {
            string xmlData = File.ReadAllText(filePath);
            root = XElement.Parse(xmlData);
            LoadObjects();
            LoadRadarScales();
            LoadScaminValues();
        }

        private void LoadRadarScales() {
            _radarScales = root.Descendants("RadarScale")
                       .Select(r => (int)r.Attribute("Value"))
                       .ToList();
        }

        private void LoadScaminValues() {
            _scaminValues = root.Descendants("SCAMIN")
                       .Select(s => (int)s.Attribute("Value"))
                       .ToList();
        }

        private List<ObjectData> LoadObjects() {
            var objects = root.Descendants("Object")
                              .Select(o => new ObjectData {
                                  Name = (string)o.Attribute("Name"),
                                  PrimitiveType = (string)o.Attribute("PrimitiveType"),
                                  HasCondition = (bool)o.Attribute("HasCondition"),
                                  DefaultStepValue = (string)o.Attribute("DefaultStepValue"),
                                  Conditions = o.Descendants("Condition")
                                                .Select(c => c.Descendants("Rule")
                                                              .Select(r => (string)r.Attribute("Type"))
                                                              .ToList())
                                                .ToList()
                              })
                              .ToList();

            return objects;
        }

        private int? GetDefaultStepValueByName(string name, PrimitiveType primitiveType) {
            var obj = root.Descendants("Object")
                          .FirstOrDefault(o => (string)o.Attribute("Name") == name && o.Attribute("PrimitiveType").ToString().ToLower().Contains(primitiveType.ToString().ToLower()));
            if (obj == null) {
                return null;
            }

            if (int.TryParse(obj.Attribute("DefaultStepValue").Value.ToString(), out var result)) {
                return result;
            }

            return null;
        }

        public int GetClosestScaminValue(int inputValue) {
            var closestScamin = _scaminValues
                                .OrderBy(v => Math.Abs(v - inputValue))
                                .FirstOrDefault();
            return closestScamin;
        }

        internal protected int? GetMinimumScale(string name, PrimitiveType primitiveType, int compilationScale) {
            var closestScamin = GetClosestScaminValue(22000);

            var defaultStepValue = GetDefaultStepValueByName(name, primitiveType);

            var higherScamins = _scaminValues.Where(v => v >= closestScamin).Order<int>().ToArray<int>();

            int? index = null;

            if (defaultStepValue.HasValue && defaultStepValue.Value > 0)
                index = defaultStepValue.Value;
            else {
                return null;
            }
            return higherScamins[index.Value];
        }

    }

    public class ObjectData
    {
        public string Name { get; set; }
        public string PrimitiveType { get; set; }
        public bool HasCondition { get; set; }
        public string DefaultStepValue { get; set; }
        public List<List<string>> Conditions { get; set; } = new List<List<string>>();
    }


}
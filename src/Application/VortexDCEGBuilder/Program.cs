using CommandLine;
using Microsoft.Extensions.Options;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace S100Framework.Applications
{
    internal class VortexDCEGBuilder
    {
        public class Options
        {
            [Option('c', "catalogue", Required = true, HelpText = "Feature Catalogue")]
            public string Catalogue { get; set; } = string.Empty;

        }

        static int Main(string[] args) {
            Logger.Current.Information("dceg_builder.exe {args}", string.Join(' ', args));

            string catalogue = string.Empty;

            var arguments = Parser.Default.ParseArguments<Options>(args)
                               .WithParsed<Options>(o => {
                                   catalogue = o.Catalogue;
                               });

            AppDomain.CurrentDomain.UnhandledException += (sender, e) => {
                Logger.Current.Fatal((Exception)e.ExceptionObject, "UnhandledException");
            };

            if (arguments.Errors.Any())
                return -1;

            var fileInfo = new FileInfo(Path.GetFullPath(catalogue));

            if (!fileInfo.Exists) {
                Logger.Current.Error("catalogue not found ({path})", fileInfo.FullName);
                return -2;
            }

            var mapping = new Mapping();

            mapping.Features.Add(new Mapping.Feature("LandRegion", "Natural features"));
            mapping.Features.Add(new Mapping.Feature("LandElevation", "Natural features"));
            mapping.Features.Add(new Mapping.Feature("SlopingGround", "Natural features"));
            mapping.Features.Add(new Mapping.Feature("SlopeTopline", "Natural features"));
            mapping.Features.Add(new Mapping.Feature("River", "Natural features"));
            mapping.Features.Add(new Mapping.Feature("Rapids", "Natural features"));
            mapping.Features.Add(new Mapping.Feature("Waterfall", "Natural features"));            
            mapping.Features.Add(new Mapping.Feature("Vegetation", "Natural features"));


            var productSpecification = XDocument.Load(fileInfo.FullName);

            var navigator = productSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);

            var productId = productSpecification.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value.Replace("-", string.Empty).ToUpperInvariant();
            var versionNumber = productSpecification.XPathSelectElement("//S100FC:versionNumber", xmlNamespaceManager)!.Value;

            var scope_S100 = scopes["S100FC"];

            var html = File.ReadAllText("dceg_template.html");            

            //  InformationTypes
            {
                var listInformations = new Dictionary<string, string>();

                foreach (var e in productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationType", xmlNamespaceManager)) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var definition = e.Element(XName.Get("definition", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    var builder = new StringBuilder();
                    builder.AppendLine($"id: \"{code}\",");
                    builder.AppendLine($"name: \"{name}\",");
                    builder.AppendLine($"definition: \"{definition}\",");
                    builder.AppendLine("category: \"Cultural Features\",");
                    builder.AppendLine("attributes: [],");
                    builder.AppendLine("associations: [],");


                    //builder.AppendLine("dceg: {");
                    //builder.AppendLine("    description: \"\",");
                    //builder.AppendLine("    encoding: [");
                    //builder.AppendLine("    ],");
                    //builder.AppendLine("    remarks: [");
                    //builder.AppendLine("    ]");
                    //builder.AppendLine("}");

                    listInformations.Add(code, builder.ToString());
                }

                var informationCategories = new Dictionary<string, List<string>>();

                int id = 1;
                var b = new StringBuilder();
                foreach (var e in listInformations) {
                    //var key = "cat1";
                    //if (!informationCategories.ContainsKey(key))
                    //    informationCategories.Add(key, new List<string>());
                    //informationCategories[key].Add(e.Key);

                    //b.AppendLine($"\"{e.Key}\": {{");
                    //b.AppendLine(e.Value);
                    //b.AppendLine("},");
                    b.AppendLine($"{{ id: \"info{id++}\", name: \"{e.Key}\" }},");
                }

                //html = html.Replace("###informationCategoriesCategoriesCat1###", string.Join(',', informationCategories["cat1"].Select(e => $"\"{e}\"")));

                html = html.Replace("###informations###", b.ToString().TrimEnd(','));
            }

            //  FeatureTypes
            {
                var listFeatures = new Dictionary<string, string>();

                foreach (var e in productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureType", xmlNamespaceManager)) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var definition = e.Element(XName.Get("definition", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;
                    //var alias = e.Element(XName.Get("alias", scope_S100))!.Value;

                    var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                    var builder = new StringBuilder();
                    builder.AppendLine($"id: \"{code}\",");
                    builder.AppendLine($"name: \"{name}\",");
                    builder.AppendLine($"definition: \"{definition}\",");
                    builder.AppendLine("category: \"Cultural Features\",");
                    builder.AppendLine("attributes: [],");
                    builder.AppendLine("associations: [],");


                    //builder.AppendLine("dceg: {");
                    //builder.AppendLine("    description: \"\",");
                    //builder.AppendLine("    encoding: [");
                    //builder.AppendLine("    ],");
                    //builder.AppendLine("    remarks: [");
                    //builder.AppendLine("    ]");
                    //builder.AppendLine("}");

                    listFeatures.Add(code, builder.ToString());
                }

                var featureCategories = new Dictionary<string, List<string>>();

                var b = new StringBuilder();
                foreach (var e in listFeatures) {
                    //var key = "General";

                    var key = mapping.Features.FirstOrDefault(f => f.Code == e.Key)?.Category;
                    if(key == default) {
                        key = "General";
                    }

                    if (!featureCategories.ContainsKey(key))
                        featureCategories.Add(key, new List<string>());
                    featureCategories[key].Add(e.Key);

                    b.AppendLine($"\"{e.Key}\": {{");
                    b.AppendLine(e.Value);
                    b.AppendLine("},");
                }
                html = html.Replace("###features###", b.ToString().TrimEnd(','));

                b.Clear();
                int id = 1;
                foreach (var e in featureCategories) {
                    b.AppendLine($"{{ id: \"cat{id++}\", name: \"{e.Key}\", features: [{string.Join(',', e.Value.Select(f=> $"\"{f}\""))}] }},");
                }

                html = html.Replace("###featureCategories###", b.ToString().TrimEnd(','));
                //html = html.Replace("###featureCategoriesCat1###", string.Join(',', featureCategories["cat1"].Select(e => $"\"{e}\"")));


            }

            File.WriteAllText(@"c:\temp\test.html", html);

            //System.Diagnostics.Debugger.Break();

            return 0;
        }
    }

    public class Mapping {
        public record Feature(string Code, string Category);

        public ICollection<Feature> Features { get; private set; } = new List<Feature>();
    }
}

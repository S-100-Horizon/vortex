using CommandLine;
using Microsoft.Extensions.Options;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using IO = System.IO;

namespace S100Framework.Applications
{
    internal class VortexRoslyn
    {
        public class Options
        {
            [Option('c', "catalogue", Required = true, HelpText = "Feature Catalogue")]
            public string Catalogue { get; set; } = string.Empty;

            [Option('o', "output", Required = false, HelpText = "Output folder")]
            public string Output { get; set; } = string.Empty;

        }

        static int Main(string[] args) {
            Logger.Current.Information("roslyn.exe {args}", string.Join(' ', args));

            string catalogue = string.Empty;
            string output = string.Empty;

            var arguments = Parser.Default.ParseArguments<Options>(args)
                               .WithParsed<Options>(o => {
                                   catalogue = o.Catalogue;
                                   output = o.Output;
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

            if (string.IsNullOrEmpty(output))
                output = fileInfo.DirectoryName!;

            var directoryInfo = new DirectoryInfo(output);
            if (!directoryInfo.Exists)
                directoryInfo.Create();

            var productSpecification = XDocument.Load(fileInfo.FullName);

            if (!VerifyProductSpecification(productSpecification)) {
                Logger.Current.Error("catalogue can't compile!", fileInfo.FullName);
                return -2;
            }


            var result = Roslyn.Build(productSpecification);

            var navigator = productSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);

            var productId = productSpecification.XPathSelectElement("//S100FC:productId", xmlNamespaceManager)!.Value.Replace("-", string.Empty).ToUpperInvariant();

            productId = $"S-{productId.Substring(1)}";
            File.WriteAllText(IO.Path.Combine(directoryInfo.FullName, $"{productId}_FC.g.cs"), result.DomainModel);
            File.WriteAllText(IO.Path.Combine(directoryInfo.FullName, $"{productId}_ViewModel.cs"), result.ViewModel);

            return 0;
        }

        private static bool VerifyProductSpecification(XDocument productSpecification) {
            var navigator = productSpecification.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var scope_S100 = scopes["S100FC"];

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);

            var result = true;

            //  Roles
            {
                var elementInformationTypes = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationTypes", xmlNamespaceManager);
                var elementFeatureTypes = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureTypes", xmlNamespaceManager);

                var elementRoles = productSpecification.XPathSelectElement("//S100FC:S100_FC_Roles", xmlNamespaceManager);
                if (elementRoles == null) {
                    // No roles !!!
                }
                else {
                    foreach (var role in elementRoles!.Elements()) {
                        var name = role.Element(XName.Get("name", scope_S100))!.Value;
                        var code = role.Element(XName.Get("code", scope_S100))!.Value;

                        //var query = $"//S100FC:featureBinding/S100FC:role[@ref=\"{code}\"]";
                        var query = $"//S100FC:role[@ref=\"{code}\"]";

                        if (elementInformationTypes.Any(e => e.XPathSelectElements(query, xmlNamespaceManager).Any())) {
                            continue;
                        }
                        if (elementFeatureTypes.Any(e => e.XPathSelectElements(query, xmlNamespaceManager).Any())) {
                            continue;
                        }

                        Logger.Current.Warning("role not used: {code}", code);
                    }
                }
            }

            //  Associations
            {
                var elementInformationAssociations = productSpecification.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);
                if (elementInformationAssociations is null) {

                }
                else {
                    foreach (var e in elementInformationAssociations) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                        var dictionary = new Dictionary<string, (int lower, int? upper)>();

                        var bindings = productSpecification.XPathSelectElements($"//S100FC:informationBinding/S100FC:association[@ref=\"{code}\"]", xmlNamespaceManager);
                        foreach (var b in bindings) {
                            var binding = b.Parent!;

                            var role = binding.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;

                            var lower = int.Parse(binding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = binding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!.Attribute(XName.Get("infinite")) != default ? default(int?) : int.Parse(binding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!.Value);

                            if (!dictionary.ContainsKey(role)) {
                                dictionary.Add(role, (lower, upper));
                            }
                            else {
                                if(!dictionary[role].Equals((lower, upper))) {
                                    Logger.Current.Error("role defined with different multiplicity ({role})", role);
                                    result = false;
                                }
                            }
                        }

                        foreach (var pair in dictionary) {
                            var upper = pair.Value.upper.HasValue ? $"{pair.Value.upper.Value}" : "∞";
                            //_output.WriteLine($"\t{pair.Key}: {pair.Value.lower} {upper}");
                        }
                        foreach (var r in roles) {
                            if (dictionary.ContainsKey(r))
                                continue;
                            Logger.Current.Warning("role not used ({role})", r);
                        }
                    }
                }

                var elementFeatureAssociations = productSpecification.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager);
                if (elementFeatureAssociations is null) {

                }
                else {
                    foreach (var e in elementFeatureAssociations) {
                        var name = e.Element(XName.Get("name", scope_S100))!.Value;
                        var code = e.Element(XName.Get("code", scope_S100))!.Value;

                        //_output.WriteLine($"{code}:");

                        var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                        var dictionary = new Dictionary<string, (int lower, int? upper)>();

                        var bindings = productSpecification.XPathSelectElements($"//S100FC:featureBinding/S100FC:association[@ref=\"{code}\"]", xmlNamespaceManager);
                        foreach (var b in bindings) {
                            var binding = b.Parent!;

                            var role = binding.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;

                            var lower = int.Parse(binding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                            var upper = binding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!.Attribute(XName.Get("infinite")) != default ? default(int?) : int.Parse(binding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!.Value);

                            if (!dictionary.ContainsKey(role)) {
                                dictionary.Add(role, (lower, upper));
                            }
                            else {
                                if (!dictionary[role].Equals((lower, upper))) {
                                    Logger.Current.Error("role defined with different multiplicity ({role})", role);
                                    result = false;
                                }                                
                            }
                        }

                        foreach (var pair in dictionary) {
                            var upper = pair.Value.upper.HasValue ? $"{pair.Value.upper.Value}" : "∞";
                            //_output.WriteLine($"\t{pair.Key}: {pair.Value.lower} {upper}");
                        }
                        foreach (var r in roles) {
                            if (dictionary.ContainsKey(r))
                                continue;
                            Logger.Current.Warning("role not used ({role})", r);
                        }
                    }
                }
            }
            return result;
        }

    }
}

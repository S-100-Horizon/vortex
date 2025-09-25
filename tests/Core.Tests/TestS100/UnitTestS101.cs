using Microsoft.VisualStudio.TestPlatform.Utilities;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Xunit.Abstractions;

namespace TestS100
{
    public class UnitTestS101
    {
        private readonly ITestOutputHelper _output;

        public UnitTestS101(ITestOutputHelper output) {
            this._output = output;
        }

        public record AssociationBinding(string Type, string RoleType, string Association, string Role, string Reference, string Multiplicity);

        [Fact]
        public void Test_Associations() {
            var documentS101 = XDocument.Load(@".\101_Feature_Catalogue_2.0.0.xml");

            var navigator = documentS101.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);
            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var scope_S100 = scopes["S100FC"];

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var e in scopes)
                xmlNamespaceManager.AddNamespace(e.Key, e.Value);


            //  Roles
            {
                var elementInformationTypes = documentS101.XPathSelectElements("//S100FC:S100_FC_InformationTypes", xmlNamespaceManager);
                var elementFeatureTypes = documentS101.XPathSelectElements("//S100FC:S100_FC_FeatureTypes", xmlNamespaceManager);

                var elementRoles = documentS101.XPathSelectElement("//S100FC:S100_FC_Roles", xmlNamespaceManager);
                if (elementRoles == null) {
                    _output.WriteLine("no roles found");
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

                        _output.WriteLine($"role not used: {code}");
                    }
                }
            }

            var assocations = new List<AssociationBinding>();

            //  Associations
            {                
                _output.WriteLine(string.Empty);
                _output.WriteLine($"S100_FC_InformationAssociation");
                _output.WriteLine("--------------------------------------------------------");
                var elementInformationAssociations = documentS101.XPathSelectElements("//S100FC:S100_FC_InformationAssociation", xmlNamespaceManager);

                foreach (var e in elementInformationAssociations) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    _output.WriteLine($"{code}:");

                    var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                    var dictionary = new Dictionary<string, (int lower, int? upper)>();

                    var bindings = documentS101.XPathSelectElements($"//S100FC:informationBinding/S100FC:association[@ref=\"{code}\"]", xmlNamespaceManager);
                    foreach (var b in bindings) {
                        var binding = b.Parent!;

                        var roleType = binding.Attribute("roleType")!.Value;

                        var parent = binding.Parent!.Element(XName.Get("code", scope_S100))!.Value;

                        var role = binding.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;

                        var lower = int.Parse(binding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                        var upper = binding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!.Attribute(XName.Get("infinite")) != default ? default(int?) : int.Parse(binding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!.Value);

                        if (!dictionary.ContainsKey(role)) {
                            dictionary.Add(role, (lower, upper));
                        }
                        else {
                            Assert.True(dictionary[role].Equals((lower, upper)));
                        }

                        var multiplicity = $"[{lower}.." + (upper.HasValue ? $"{upper}]" : "*]");

                        foreach(var t in binding.Elements(XName.Get("informationType", scope_S100))) {
                            var reference = t.Attribute("ref")!.Value;

                            assocations.Add(new AssociationBinding(parent, roleType, code, role, reference, multiplicity));
                        }
                    }

                    foreach (var pair in dictionary) {
                        var upper = pair.Value.upper.HasValue ? $"{pair.Value.upper.Value}" : "∞";
                        _output.WriteLine($"\t{pair.Key}: {pair.Value.lower} {upper}");
                    }
                    foreach (var r in roles) {
                        if (dictionary.ContainsKey(r))
                            continue;
                        _output.WriteLine($"\t{r} not used!");
                    }

                    _output.WriteLine("");
                }

                _output.WriteLine(string.Empty);
                _output.WriteLine($"S100_FC_FeatureAssociation");
                _output.WriteLine("--------------------------------------------------------");
                var elementFeatureAssociations = documentS101.XPathSelectElements("//S100FC:S100_FC_FeatureAssociation", xmlNamespaceManager);
                foreach (var e in elementFeatureAssociations) {
                    var name = e.Element(XName.Get("name", scope_S100))!.Value;
                    var code = e.Element(XName.Get("code", scope_S100))!.Value;

                    _output.WriteLine($"{code}:");

                    var roles = e.Elements(XName.Get("role", scope_S100)).Select(e => e.Attribute("ref")!.Value);

                    var dictionary = new Dictionary<string, (int lower, int? upper)>();

                    var bindings = documentS101.XPathSelectElements($"//S100FC:featureBinding/S100FC:association[@ref=\"{code}\"]", xmlNamespaceManager);
                    foreach (var b in bindings) {
                        var binding = b.Parent!;

                        var roleType = binding.Attribute("roleType")!.Value;

                        var parent = binding.Parent!.Element(XName.Get("code", scope_S100))!.Value;

                        var role = binding.Element(XName.Get("role", scope_S100))!.Attribute("ref")!.Value;

                        var lower = int.Parse(binding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                        var upper = binding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!.Attribute(XName.Get("infinite")) != default ? default(int?) : int.Parse(binding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!.Value);

                        if (!dictionary.ContainsKey(role)) {
                            dictionary.Add(role, (lower, upper));
                        }
                        else {
                            Assert.True(dictionary[role].Equals((lower, upper)));
                        }

                        var multiplicity = $"[{lower}.." + (upper.HasValue ? $"{upper}]" : "*]");

                        foreach (var t in binding.Elements(XName.Get("featureType", scope_S100))) {
                            var reference = t.Attribute("ref")!.Value;

                            assocations.Add(new AssociationBinding(parent, roleType, code, role, reference, multiplicity));
                        }
                    }

                    foreach (var pair in dictionary) {
                        var upper = pair.Value.upper.HasValue ? $"{pair.Value.upper.Value}" : "∞";
                        _output.WriteLine($"\t{pair.Key}: {pair.Value.lower} {upper}");
                    }
                    foreach (var r in roles) {
                        if (dictionary.ContainsKey(r))
                            continue;
                        _output.WriteLine($"\t{r} not used!");
                    }
                    _output.WriteLine("");
                }
            }

            _output.WriteLine($"InformationType/FeatureType;RoleType;Association;Role;Reference;Multiplicity");
            foreach (var e in assocations.OrderBy(e => e.Type).ThenBy(e => e.Role)) {
                _output.WriteLine($"{e.Type};{e.RoleType};{e.Association};{e.Role};{e.Reference};{e.Multiplicity}");
            }
        }
    }
}
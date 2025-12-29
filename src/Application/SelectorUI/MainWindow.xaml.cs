using PropertyGridApplication;
using S100Framework.DomainModel.S101;
using S100Framework.DomainModel.S101.ComplexAttributes;
using S100Framework.DomainModel.S101.FeatureTypes;

using S100Framework.WPF;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;
using Windows.Media.Protection.PlayReady;
using Windows.System;
using static System.Formats.Asn1.AsnWriter;

namespace SelectorUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            var viewModel = new CustomViewModel() {
                buoyShape = buoyShape.Barrel,
                MyValue = 123,
            };
            viewModel.colour.Add((colour)3);
            viewModel.featureName.Add(new S100Framework.WPF.ViewModel.S101.featureNameViewModel {
                language = "eng",
                name = "Hello World",
                nameUsage = nameUsage.DefaultNameDisplay,
            });

            var root = Environment.GetEnvironmentVariable("GITHUB-IHO")!;

            var s100 = XDocument.Load(System.IO.Path.Combine(root, @"S-101-Documentation-and-FC\S-101FC\FeatureCatalogue.xml"));

            var navigator = s100.CreateNavigator();
            navigator.MoveToFollowing(XPathNodeType.Element);

            var scopes = navigator.GetNamespacesInScope(XmlNamespaceScope.All);

            var xmlNamespaceManager = new XmlNamespaceManager(new NameTable());
            foreach (var s in scopes)
                xmlNamespaceManager.AddNamespace(s.Key, s.Value);

            var attributes = new List<S100Framework.WPF.Attribute>();

            foreach (var element in s100.XPathSelectElements("//S100FC:S100_FC_SimpleAttribute", xmlNamespaceManager)) {
                var valueType = element.Element(XName.Get("valueType", scopes["S100FC"]))!.Value;

                if (valueType.Equals("enumeration")) {
                    var enumeration = new SimpleEnumerationAttribute {
                        code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value,
                        name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value,
                        valueType = element.Element(XName.Get("valueType", scopes["S100FC"]))!.Value,
                    };

                    foreach (var listedValue in element.Element(XName.Get("listedValues", scopes["S100FC"]))!.Elements()) {
                        var listedValueLabel = listedValue.Element(XName.Get("label", scopes["S100FC"]))!.Value!;
                        var listedValueDefinition = listedValue.Element(XName.Get("definition", scopes["S100FC"]))!.Value!;
                        var listedValueCode = listedValue.Element(XName.Get("code", scopes["S100FC"]))!.Value!;

                        enumeration.listedValues = [.. enumeration.listedValues, new listedValue(listedValueLabel,listedValueDefinition,int.Parse(listedValueCode))];
                    }
                    attributes.Add(enumeration);
                }
                else if (valueType.Equals("S100_CodeList")) {
                    var codelist = new SimpleCodeListAttribute {
                        code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value,
                        name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value,
                        valueType = element.Element(XName.Get("valueType", scopes["S100FC"]))!.Value,
                    };

                    foreach (var listedValue in element.Element(XName.Get("listedValues", scopes["S100FC"]))!.Elements()) {
                        var listedValueLabel = listedValue.Element(XName.Get("label", scopes["S100FC"]))!.Value!;
                        var listedValueDefinition = listedValue.Element(XName.Get("definition", scopes["S100FC"]))!.Value!;
                        var listedValueCode = listedValue.Element(XName.Get("code", scopes["S100FC"]))!.Value!;

                        codelist.listedValues = [.. codelist.listedValues, new listedValue(listedValueLabel, listedValueDefinition, int.Parse(listedValueCode))];
                    }
                    attributes.Add(codelist);
                }
                else {
                    attributes.Add(new SimpleAttribute {
                        code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value,
                        name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value,
                        valueType = element.Element(XName.Get("valueType", scopes["S100FC"]))!.Value,
                    });
                }
            }

            var notFinished = false;
            do {
                notFinished = false;
                foreach (var element in s100.XPathSelectElements("//S100FC:S100_FC_ComplexAttribute", xmlNamespaceManager)) {
                    var code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value;
                    if (attributes.Any(a => a.code.Equals(code)))
                        continue;

                    if (!element.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)
                        .All(attribute => attributes.Any(a => a.code.Equals(attribute.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!)))) {
                        notFinished = true;
                        continue;
                    }

                    var complexAtttribute = new ComplextAttribute {
                        code = element.Element(XName.Get("code", scopes["S100FC"]))!.Value,
                        name = element.Element(XName.Get("name", scopes["S100FC"]))!.Value,
                    };
                    foreach (var subAttributeBinding in element.XPathSelectElements("S100FC:subAttributeBinding", xmlNamespaceManager)) {
                        var referenceCode = subAttributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                        var permittedValues = subAttributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                        var lower = int.Parse(subAttributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                        var _ = subAttributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                        int? upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? null : int.Parse(_.Value!);

                        complexAtttribute.subAttributeBindings = [
                                .. complexAtttribute.subAttributeBindings,
                                new AttributeBinding{
                                    lower = lower,
                                    upper = upper.HasValue ? upper.Value : int.MaxValue,
                                    FreeSeats = upper.HasValue ? upper.Value : int.MaxValue,
                                    attribute = attributes.First(a=>a.code.Equals(referenceCode)),
                                    permitedValues = permittedValues is null ? [] : permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => int.Parse(e.Value)).ToArray(),
                                }
                            ];

                    }

                    attributes.Add(complexAtttribute);
                }
            } while (notFinished);


            var lightSectored = s100.XPathSelectElement("//S100FC:S100_FC_FeatureType[S100FC:code='LightSectored']", xmlNamespaceManager)!;


            var featureType = new FeatureType {
                Code = lightSectored.Element(XName.Get("code", scopes["S100FC"]))!.Value,
            };

            foreach (var attributeBinding in lightSectored.XPathSelectElements("S100FC:attributeBinding", xmlNamespaceManager)) {
                var referenceCode = attributeBinding.Element(XName.Get("attribute", scopes["S100FC"]))!.Attribute("ref")!.Value!;
                var permittedValues = attributeBinding.XPathSelectElement("S100FC:permittedValues", xmlNamespaceManager);
                var lower = int.Parse(attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:lower", xmlNamespaceManager)!.Value);
                var _ = attributeBinding.XPathSelectElement("S100FC:multiplicity/S100Base:upper", xmlNamespaceManager)!;
                int? upper = (_.Attribute(XName.Get("infinite")) != default && _.Attribute(XName.Get("infinite"))!.Value.Equals("true")) ? null : int.Parse(_.Value!);


                featureType.attributeBindings = [
                        .. featureType.attributeBindings,
                        new AttributeBinding{
                            lower = lower,
                            upper = upper.HasValue ? upper.Value : int.MaxValue,
                            FreeSeats = upper.HasValue ? upper.Value : int.MaxValue,
                            attribute = attributes.First(a=>a.code.Equals(referenceCode)),
                            permitedValues = permittedValues is null ? [] : permittedValues.XPathSelectElements("S100FC:value", xmlNamespaceManager).Select(e => int.Parse(e.Value)).ToArray(),
                        },
                    ];
            }

            var selectedObject = new SelectedObject {
                code = featureType.Code,
                attributeBindings = featureType.attributeBindings,
            };

            var featureName = (ComplextAttribute)attributes.Single(e => e.code.Equals("featureName"));


            selectedObject.AttributeValues = [
                    new SimpleAttributeValue{
                        code = "categoryOfLight",
                        Value = (int)categoryOfLight.SubsidiaryLight,
                        attributeBinding = selectedObject.attributeBindings.Single(e=>e.Name.Equals("categoryOfLight")),
                    },
                    new SimpleAttributeValue{
                        code = "categoryOfLight",
                        Value = (int)categoryOfLight.AeroLight,
                        attributeBinding = selectedObject.attributeBindings.Single(e=>e.Name.Equals("categoryOfLight")),
                    },
                    new SimpleAttributeValue{
                        code = "scaleMinimum",
                        Value = 179999,
                        attributeBinding = selectedObject.attributeBindings.Single(e=>e.Name.Equals("scaleMinimum")),
                    },
                    new ComplextAttributeValue{
                        code = "featureName",
                        attributeBinding = selectedObject.attributeBindings.Single(e=>e.Name.Equals("featureName")),
                        attributeValues = [
                                new SimpleAttributeValue{
                                    code = "language",
                                    Value = "eng",
                                    attributeBinding = featureName.subAttributeBindings.Single(e=>e.Name.Equals("language")),
                                },
                                new SimpleAttributeValue{
                                    code = "name",
                                    Value = "Hello World",
                                    attributeBinding = featureName.subAttributeBindings.Single(e=>e.Name.Equals("name")),
                                },
                                new SimpleAttributeValue{
                                    code = "nameUsage",
                                    Value = (int)nameUsage.DefaultNameDisplay,
                                    attributeBinding = featureName.subAttributeBindings.Single(e=>e.Name.Equals("nameUsage")),
                                }
                            ]
                    },
                ];

            this.PropertyGrid.SelectedObject = selectedObject;

            this.PropertyGrid.PropertyChanged += this.PropertyGrid_PropertyChanged;
        }

        private void PropertyGrid_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e) {

        }
    }
}
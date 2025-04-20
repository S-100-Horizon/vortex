using CommandLine;
using Microsoft.Extensions.Options;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.XPath;

namespace S100Framework.Applications
{
    internal class VortexRoslyn
    {
        public class Options
        {
            [Option('c', "catalogue", Required = true, HelpText = "Feature Catalogue")]
            public string Catalogue { get; set; } = string.Empty;

        }

        static int Main(string[] args) {
            Logger.Current.Information("roslyn.exe {args}", string.Join(' ', args));

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

            var productSpecification = XDocument.Load(fileInfo.FullName);

            var result = Roslyn.Build(productSpecification);

            File.WriteAllText(@".\..\..\..\domainmodel.g.cs", result.DomainModel);
            File.WriteAllText(@".\..\..\viewmodel.g.cs", result.ViewModel.Replace("S100Framework.WPF.ViewModel.S101", "S100Framework.WPF.ViewModel.S10x"));

            return 0;
        }
    }
}

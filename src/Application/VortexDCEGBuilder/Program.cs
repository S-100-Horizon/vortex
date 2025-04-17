using CommandLine;
using Microsoft.Extensions.Options;
using System.Xml.Linq;

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

            var fileInfo =new FileInfo(Path.GetFullPath(catalogue));

            if (!fileInfo.Exists) {
                Logger.Current.Error("catalogue not found ({path})", fileInfo.FullName);
                return -2;
            }

            var s100 = XDocument.Load(fileInfo.FullName);

            System.Diagnostics.Debugger.Break();

            return 0;
        }
    }
}

using ArcGIS.Core.Data;
using ICSharpCode.SharpZipLib.Zip;
using S100Framework.EventSourcing;
using System.Reflection;
using System.Text.Json;
using VortexAPI.EventSourcing.DomainModel;
using Xunit.Abstractions;
using IO = System.IO;

namespace EventSourcing.Tests
{
    public class StateTest
    {
        private readonly ITestOutputHelper output;

        private static readonly JsonSerializerOptions jsonSerializerOptions = new() {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            PropertyNameCaseInsensitive = true,
        };

        public StateTest(ITestOutputHelper output) {
            this.output = output;

            ArcGIS.Core.Hosting.Host.Initialize();
        }

        [Fact]
        public async void Test1() {
            FastZip fastZip = new();

            var output = new IO.DirectoryInfo(@"s100ed7.gdb");
            if (output.Exists)
                output.Delete(true);

            fastZip.ExtractZip("s100ed7.gdb.zip", output.FullName, null);

            
            var eventStore = EventStore.OpenEventStore(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(output.FullName))), CancellationToken.None);


            var controller = new VortexAPI.ProductsCommandController(eventStore);


            var streamname = $"product::DK4LIMFE";

            controller.Handle(new VortexAPI.ProductsCommandController.CreateProduct("DK4LIMFE"), CancellationToken.None);
            controller.Handle(new VortexAPI.ProductsCommandController.UpdateName("DK4LIMFE", "Kattegat - Randers Fjord - Mariager Fjord - Entrance to Limfjorden"), CancellationToken.None); 

            var state = await eventStore.LoadState<ProductState>(streamname);

            System.Diagnostics.Debugger.Break();

        }
    }
}

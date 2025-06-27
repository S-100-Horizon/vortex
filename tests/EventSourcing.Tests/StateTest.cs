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

            var createProduct = new VortexAPI.EventSourcing.Products.v1.Created("DK4LIMFE");

            var updateName = new VortexAPI.EventSourcing.Products.v1.NameUpdated("Kattegat - Randers Fjord - Mariager Fjord - Entrance to Limfjorden");

            var eventStore = EventStore.OpenEventStore(new FileGeodatabaseConnectionPath(new Uri(IO.Path.GetFullPath(output.FullName))), CancellationToken.None);

            var options = new ParallelOptions { MaxDegreeOfParallelism = 8 };
            //Parallel.For(0, 124, options, async (i) => {
            var streamname = $"test::product::{DateTime.Now.Ticks}";



            await eventStore.WriteStream<object>(streamname, [createProduct, updateName], false);
            //});            


            var state = await eventStore.LoadState<ProductState>(streamname);

            System.Diagnostics.Debugger.Break();

        }
    }
}

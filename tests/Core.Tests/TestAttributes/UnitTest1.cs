using Xunit.Abstractions;

namespace TestAttributes
{
    public class UnitTestAttributes
    {
        private readonly ITestOutputHelper _output;

        private readonly string _iho;
        private readonly string _iala;

        public UnitTestAttributes(ITestOutputHelper output) {
            this._output = output;

            this._iho = Environment.GetEnvironmentVariable("GITHUB-IHO")!;
            this._iala = Environment.GetEnvironmentVariable("GITHUB-IALA")!;
        }

        [Fact]
        public void Test_Serialization() {

        }
    }
}
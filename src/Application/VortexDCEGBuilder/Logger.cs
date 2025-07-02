using Serilog;

namespace S100Framework.Applications
{
    internal static class Logger
    {
        private static string _dateTimeString = DateTime.Now.ToString("yyyyMMdd-HHmmss");
        private static Serilog.Core.Logger _logger;
        private static string _logDir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);

        public static ILogger Current => _logger;

        static Logger() {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.Logger(lc => lc
                    .Enrich.WithExceptionData()
                    .WriteTo.Console()
                    .WriteTo.File(System.IO.Path.Combine(_logDir, @"Vortex", "DCEG", $"{_dateTimeString}", "DCEG_System.log"),
                    rollingInterval: RollingInterval.Infinite,
                    shared: true,
                    encoding: System.Text.Encoding.GetEncoding("ISO-8859-1"),
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| [{Level:u3}] {Message:lj} {NewLine}{Exception}"))

                .WriteTo.Logger(lc => lc
                    .MinimumLevel.Error()
                    .WriteTo.File(System.IO.Path.Combine(_logDir, @"Vortex", "DCEG", $"{_dateTimeString}", $"DCEG_Error.log"),
                    rollingInterval: RollingInterval.Infinite,
                    shared: true,
                    encoding: System.Text.Encoding.GetEncoding("ISO-8859-1"),
                    outputTemplate: "{Message:lj}{NewLine}"))

                .CreateLogger();
        }
    }
}

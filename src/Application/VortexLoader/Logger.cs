using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace VortexLoader
{

    public enum LogLevel
    {
        Verbose = 0,
        Debug = 1,
        Information = 2,
        Warning = 3,
        Error = 4,
        Fatal = 5,
        DataObject = 6,
        DataTotalCount = 7,
        DataError = 8
    }

    public class DynamicFileSink : ILogEventSink
    {
        private readonly string _logDirectory;

        public DynamicFileSink(string logDirectory) {
            _logDirectory = logDirectory;
        }

        public void Emit(LogEvent logEvent) {
            var logFileName = logEvent.Properties.ContainsKey("TableName")
                ? logEvent.Properties["TableName"].ToString().Trim('"')
                : throw new Exception("TableName not supplied");  

            var filePath = Path.Combine(_logDirectory, $"Loader_DataObject_{logFileName}_.log");

            using (var writer = new StreamWriter(filePath, true)) {
                writer.WriteLine($"{logEvent.RenderMessage()}");
            }
        }
    }

    public static class CustomLogLevels
    {
        public static void DataTotalCount(this ILogger logger, string tablename, int totalCount, int convertedCount) {
            logger.Write(LogLevel.DataTotalCount.ToLogLevel(), "{tablename};{totalCount};{convertedCount}", tablename,totalCount,convertedCount);
        }

        public static void DataObject(this ILogger logger, int objectId, string tableName, string longname, string destination) {
            logger.Write(LogLevel.DataObject.ToLogLevel(), "{ObjectId};{TableName};{LongName};{Destination}", objectId, tableName, longname, destination);

        }

        public static void DataObject(ILogger logger, string fileName, string message) {
            // Log with custom property that indicates the file name
            logger.ForContext("LogFileName", fileName)
                  .Debug(message);
        }


        public static void DataError(this ILogger logger, int objectId, string tableName, string longname, string message) {
            logger.Write(LogLevel.DataError.ToLogLevel(), "{ObjectId};{TableName};{LongName};{Message}", objectId, tableName, longname, message);
        }

        //private static WriteHeader()

        // Convert custom LogLevel enum to LogEventLevel
        public static LogEventLevel ToLogLevel(this LogLevel logLevel) {
            return logLevel switch {
                LogLevel.Verbose => LogEventLevel.Verbose,
                LogLevel.Debug => LogEventLevel.Debug,
                LogLevel.Information => LogEventLevel.Information,
                LogLevel.Warning => LogEventLevel.Warning,
                LogLevel.Error => LogEventLevel.Error,
                LogLevel.Fatal => LogEventLevel.Fatal,
                LogLevel.DataObject => (LogEventLevel)6,
                LogLevel.DataTotalCount => (LogEventLevel)7,
                LogLevel.DataError => (LogEventLevel)8,
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    internal static class Logger
    {
        private static Serilog.Core.Logger _logger;
        
        public static ILogger Current => _logger;

        static Logger() {
            _logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()  
                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level < (LogEventLevel)6)
                    .Enrich.WithExceptionData()
                    .WriteTo.File(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Vortex", "Loader", "Loader_System_.log"),
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| [{Level:u3}] {Message:lj} {NewLine}{Exception}"))

                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == (LogEventLevel)6)
                    .WriteTo.Sink(new DynamicFileSink(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Vortex", "Loader"))))

                .WriteTo.Logger(lc => lc
                    .WriteTo.Console()
                    .Filter.ByIncludingOnly(e => e.Level == (LogEventLevel)7)
                    .WriteTo.File(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Vortex", "Loader", "Loader_DataTotalCount_.log"),
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    outputTemplate: "{Message:lj}{NewLine}"))

                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == (LogEventLevel)8)
                    .WriteTo.File(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Vortex", "Loader", "Loader_DataError_.log"),
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    outputTemplate: "{Message:lj}{NewLine}"))

                .CreateLogger();



        }
    }
}

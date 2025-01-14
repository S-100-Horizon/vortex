using ArcGIS.Core.CIM;
using ArcGIS.Core.Data.UtilityNetwork.Trace;
using Serilog;
using Serilog.Events;
using System;

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
        DataTotalCount = 7  
    }

    public static class CustomLogLevels
    {
        // Helper method to log DataIssue level
        public static void DataObject(this ILogger logger, string message) {
            logger.Write(LogLevel.DataObject.ToLogLevel(), message);
        }
        public static void DataTotalCount(this ILogger logger, string message) {
            logger.Write(LogLevel.DataTotalCount.ToLogLevel(), message);
        }

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
                    .WriteTo.File(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Vortex", "Loader", "Loader-System.log"),
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| [{Level:u3}] {Message:lj} {NewLine}{Exception}"))

                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == (LogEventLevel)6)
                    .WriteTo.File(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Vortex", "Loader", "Loader-DataObjects.log"),
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    outputTemplate: "{Message:lj}{NewLine}"))

                .WriteTo.Logger(lc => lc
                    .Filter.ByIncludingOnly(e => e.Level == (LogEventLevel)7)
                    .WriteTo.File(System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Vortex", "Loader", "Loader-DataTotalCount.log"),
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    outputTemplate: "{Message:lj}{NewLine}"))

                .CreateLogger();

        }
    }
}

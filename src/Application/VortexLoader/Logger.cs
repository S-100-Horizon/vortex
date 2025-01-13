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
        DataIssue = 6  // Custom log level
    }

    // Step 2: Custom log level extension methods
    public static class CustomLogLevels
    {
        // Helper method to log DataIssue level
        public static void DataIssue(this ILogger logger, string message) {
            logger.Write(LogLevel.DataIssue.ToLogLevel(), message);
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
                LogLevel.DataIssue => (LogEventLevel)6,  // Custom level mapping
                _ => throw new ArgumentOutOfRangeException()
            };
        }
    }

    internal static class Logger
    {

        public enum Issue
        {
            MissingValue,
            DataTypeMismatch
        }

        private static Serilog.Core.Logger _logger;
        
        public static ILogger Current => _logger;

        private const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| [{Level:u3}] {Message:lj} {NewLine}{Exception}";


        public static void DataIssue(this ILogger logger, int objectId, string tableName, Issue issue) {
            // Log the issue with structured information
            _logger.Information("ObjectId: {ObjectId}, Table: {TableName}, Issue: {Issue}", objectId, tableName, issue);
        }

        static Logger() {
            _logger = new LoggerConfiguration()
                                    .MinimumLevel.Verbose()
                                    .Enrich.WithExceptionData()
                                    .Enrich.WithProperty("MachineName", Environment.MachineName)

            .WriteTo.File(
                    System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Vortex", "Loader", "Loader-DataIssues.log"),
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| [{Level:u3}] {Message:lj} {NewLine}{Exception}").
                    
            Filter.ByExcluding(logEvent => logEvent.Level < (LogEventLevel)6)

            .WriteTo.File(
                    System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Vortex", "Loader", "Loader-.log"),
                    rollingInterval: RollingInterval.Day,
                    shared: true,
                    outputTemplate: "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| [{Level:u3}] {Message:lj} {NewLine}{Exception}",
                    restrictedToMinimumLevel: (LogEventLevel)6
            )

            .CreateLogger();
        }
    }
}

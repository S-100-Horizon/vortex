using Serilog;

using System;

namespace VortexProAppModule
{
    internal static class Logger
    {
        public static ILogger Current => _logger;

        private static Serilog.Core.Logger _logger;

        private const string outputTemplate = "{Timestamp:yyyy-MM-dd HH:mm:ss.fff}| [{Level:u3}] {Message:lj} {NewLine}{Exception}";

        //public static ILogger WithClassAndMethodNames<T>(this ILogger logger, [CallerMemberName] string memberName = "")
        //{
        //    var className = typeof(T).Name;
        //    return logger.ForContext("ClassName", className).ForContext("MethodName", memberName);
        //}

        static Logger() {
            var configuration = new LoggerConfiguration()
                 .MinimumLevel.Verbose()
                 //.Enrich.FromLogContext()
                 .Enrich.WithExceptionData()
                 .Enrich.WithProperty("MachineName", Environment.MachineName);

            configuration = configuration.WriteTo.File(
                    System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"Vortex", "VortexProAppModule", "vortex-developer.log"),
                    rollingInterval: RollingInterval.Infinite,
                    retainedFileCountLimit: 1,
                    shared: true,
                    outputTemplate: outputTemplate);

            _logger = configuration.CreateLogger();
        }
    }
}

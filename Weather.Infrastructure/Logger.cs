using Serilog;
using ILogger = Weather.Core.Interfaces.ILogger;

namespace Weather.Infrastructure
{
    internal class Logger : ILogger
    {
        public Logger()
        {
            // Init logging
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("/logs/log.txt", rollingInterval: RollingInterval.Day)
                .CreateLogger();
        }

        public void CloseAndFlush()
        {
            Log.CloseAndFlush();
        }

        public void Debug(string message)
        {
            Log.Debug(message);
        }

        public void Error(string message, Exception ex)
        {
            Log.Error(message, ex);
        }

        public void Information(string message)
        {
            Log.Information(message);
        }

        public void Warning(string message)
        {
            Log.Warning(message);
        }
    }
}

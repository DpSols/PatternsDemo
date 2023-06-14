using NLog;
using NLog.Config;
using NLog.Layouts;
using NLog.Targets;

namespace Core.Utilities
{
    public sealed class Logger
    {
        private static readonly Lazy<Logger> s_lazyLogger = new Lazy<Logger>(() => new Logger());
        private readonly ILogger _logger = LogManager.GetLogger(Thread.CurrentThread.ManagedThreadId.ToString());

        private Logger()
        {
            try
            {
                LogManager.LoadConfiguration("NLog.config");
            }
            catch (FileNotFoundException)
            {
                LogManager.Configuration = GetConfiguration;
            }
        }

        private LoggingConfiguration GetConfiguration
        {
            get
            {
                string messageFormat = "${date:format=yyyy-MM-dd HH\\:mm\\:ss} ${level:uppercase=true} - ${message}";
                var configuration = new LoggingConfiguration();

                // Console target
                LogLevel info = LogLevel.Info;
                LogLevel consoleFatal = LogLevel.Fatal;
                ConsoleTarget consoleTarget = new ConsoleTarget("logconsole");
                consoleTarget.Layout = (Layout)messageFormat;
                configuration.AddRule(info, consoleFatal, consoleTarget);

                // File target
                LogLevel debug = LogLevel.Debug;
                LogLevel filefatal = LogLevel.Fatal;
                var fileTarget = new FileTarget("logfile");
                fileTarget.DeleteOldFileOnStartup = true;
                fileTarget.FileName = "../Logs/log.log";
                consoleTarget.Layout = (Layout)messageFormat;
                configuration.AddRule(debug, filefatal, fileTarget);

                return configuration;
            }
        }

        public static Logger Instance => s_lazyLogger.Value;

        public void Debug(string message) => _logger.Debug(message);
        public void Info(string message) => _logger.Info(message);
        public void Warn(string message) => _logger.Warn(message);
        public void Error(string message) => _logger.Error(message);
        public void Fatal(string message) => _logger.Fatal(message);
    }
}
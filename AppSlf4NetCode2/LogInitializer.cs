using log4net;
using log4net.Config;
using log4net.Util;
using slf4net;
using slf4net.Factories;
using slf4net.log4net;
using System.IO;

namespace AppSlf4NetCode2
{
    internal static class LogInitializer
    {
        internal static void Initialize()
        {
            var configFile = new FileInfo(Path.Combine(SystemInfo.ApplicationBaseDirectory, "log4net.config"));
            XmlConfigurator.ConfigureAndWatch(configFile);

            var loggerFactory = new SimpleLog4netLoggerFactory();
            LoggerFactory.SetServiceProviderResolver(loggerFactory);
        }
    }

    public class SimpleLog4netLoggerFactory : NamedLoggerFactoryBase,
                                                ILoggerFactory,
                                                ISlf4netServiceProvider,
                                                ISlf4netServiceProviderResolver
    {
        private readonly IMdcAdapter _mdcAdapter = new Log4netMdcAdapter();

        protected override ILogger CreateLogger(string name)
            => new Log4netLoggerAdapter(LogManager.GetLogger(name));

        public ILoggerFactory GetLoggerFactory() => this;

        public IMdcAdapter GetMdcAdapter() => _mdcAdapter;

        public ISlf4netServiceProvider GetProvider() => this;
    }
}

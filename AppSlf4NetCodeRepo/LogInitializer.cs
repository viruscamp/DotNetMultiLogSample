using log4net;
using log4net.Config;
using slf4net;
using slf4net.Factories;
using slf4net.log4net;
using System;
using System.IO;

namespace AppSlf4NetCodeRepo
{
    internal static class LogInitializer
    {
        internal static void Initialize()
        {
            var configFile = new FileInfo(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "log4net.config"));
            var myRepo = LogManager.CreateRepository("my-repo");
            XmlConfigurator.ConfigureAndWatch(myRepo, configFile);

            var loggerFactory = new RepositoryLog4netLoggerFactory(myRepo.Name);
            LoggerFactory.SetServiceProviderResolver(loggerFactory);
        }
    }

    public class RepositoryLog4netLoggerFactory : NamedLoggerFactoryBase,
                                                ILoggerFactory,
                                                ISlf4netServiceProvider,
                                                ISlf4netServiceProviderResolver
    {
        private readonly IMdcAdapter _mdcAdapter = new Log4netMdcAdapter();
        private readonly string repository;

        public RepositoryLog4netLoggerFactory(string repository) => this.repository = repository;

        protected override ILogger CreateLogger(string name)
            => new Log4netLoggerAdapter(LogManager.GetLogger(repository, name));

        public ILoggerFactory GetLoggerFactory() => this;

        public IMdcAdapter GetMdcAdapter() => _mdcAdapter;

        public ISlf4netServiceProvider GetProvider() => this;
    }
}

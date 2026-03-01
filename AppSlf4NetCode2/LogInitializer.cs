using log4net;
using log4net.Config;
using log4net.Util;
using slf4net;
using slf4net.Factories;
using slf4net.log4net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AppSlf4NetCode2
{
    internal static class LogInitializer
    {
        internal static void Initialize()
        {
            var configFile = new FileInfo(Path.Combine(SystemInfo.ApplicationBaseDirectory, "log4net.config"));
            XmlConfigurator.ConfigureAndWatch(configFile);

            var loggerFactory = new SimpleLog4netLoggerFactory();
            var resolver = new SimpleSlf4netFactoryResolver(loggerFactory);
            LoggerFactory.SetFactoryResolver(resolver);
        }
    }

    /// <summary>
    /// A simple implementation of slf4net.IFactoryResolver
    /// </summary>
    public class SimpleSlf4netFactoryResolver : IFactoryResolver
    {
        private ILoggerFactory _factory;

        /// <summary>
        /// The constructor takes the ILoggerFactory to be used by slf4net
        /// </summary>
        public SimpleSlf4netFactoryResolver(ILoggerFactory factory)
        {
            _factory = factory;
        }

        /// <summary>
        /// IFactoryResolver GetFactory() implementation
        /// </summary>
        public ILoggerFactory GetFactory()
        {
            return _factory;
        }
    }

    /// <summary>
    /// An implementation of the slf4net.ILoggerFactory interface which creates slf4net.ILogger
    /// use only configured global Log4net Repository
    /// </summary>
    public class SimpleLog4netLoggerFactory : NamedLoggerFactoryBase, ILoggerFactory, ISlf4netServiceProvider
    {
        private readonly Log4netMdcAdapter _mdcAdapter = new Log4netMdcAdapter();

        protected override ILogger CreateLogger(string name)
        {
            ILog logger = LogManager.GetLogger(name);
            return new Log4netLoggerAdapter(logger);
        }

        public ILoggerFactory GetLoggerFactory()
        {
            return this;
        }

        public IMdcAdapter GetMdcAdapter()
        {
            return _mdcAdapter;
        }
    }
}

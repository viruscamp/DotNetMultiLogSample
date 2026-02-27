using slf4net;
using slf4net.log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSlf4NetCode
{
    internal static class Slf4NetInitializer
    {
        internal static void Initialize()
        {
            var loggerFactory = new Log4netLoggerFactory();
            loggerFactory.Init("<factory-data><configFile value=\"log4net.config\" /><watch value=\"true\" /></factory-data>");
            var resolver = new SimpleFactoryResolver(loggerFactory);
            LoggerFactory.SetFactoryResolver(resolver);
        }
    }

    /// <summary>
    /// A simple implementation of IFactoryResolver
    /// </summary>
    public class SimpleFactoryResolver : IFactoryResolver
    {
        private ILoggerFactory _factory;

        /// <summary>
        /// The constructor takes the ILoggerFactory to be used by slf4net
        /// </summary>
        public SimpleFactoryResolver(ILoggerFactory factory)
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
}

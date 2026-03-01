using Common.Logging;
using Common.Logging.Configuration;
using Common.Logging.Log4Net;
using log4net.Util;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace AppCommonLoggingCode2
{
    internal static class LogInitializer
    {
        internal static void Initialize()
        {
            var configFile = new FileInfo(Path.Combine(SystemInfo.ApplicationBaseDirectory, "log4net.config"));
            log4net.Config.XmlConfigurator.ConfigureAndWatch(configFile);

            var nameValues = new NameValueCollection();
            nameValues.Add("configType", "EXTERNAL");
            var loggerFactoryAdapter = new Log4NetLoggerFactoryAdapter(nameValues);
            LogManager.Adapter = loggerFactoryAdapter;
        }
    }
}

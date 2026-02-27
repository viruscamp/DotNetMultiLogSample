using Common.Logging;
using Common.Logging.Log4Net;
using Common.Logging.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCommonLoggingCode
{
    internal static class CommonLoggingInitializer
    {
        internal static void Initialize()
        {
            var nameValues = new NameValueCollection();
            // configType: INLINE|FILE|FILE-WATCH|EXTERNAL
            nameValues.Add("configType", "FILE-WATCH");
            // configFile: log4net configuration file path in case of FILE or FILE-WATCH
            nameValues.Add("configFile", "log4net.config");
            var loggerFactoryAdapter = new Log4NetLoggerFactoryAdapter(nameValues);
            LogManager.Adapter = loggerFactoryAdapter;
        }
    }
}

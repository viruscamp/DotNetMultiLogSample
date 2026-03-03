using Microsoft.Extensions.Logging;
using NLog.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ModuleInitializer
{
    private static ILoggerFactory _loggerFactory;

    public static void Initialize()
    {
        _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.ClearProviders();
            builder.AddNLog();
        });
        LibUseMEL.Global.LoggerFactory = _loggerFactory;

        log4net.NLogAppender.Initialize();
        log4net.NLogAppender1210Initializer.Initialize();
    }
}
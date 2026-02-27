using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class ModuleInitializer
{
    public static void Initialize()
    {
        log4net.NLogAppender.Initialize();
        log4net.NLogAppender1210Initializer.Initialize();
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCommonLoggingCode
{
    internal class Program
    {
        static Common.Logging.ILog Log { get; }

        static Program()
        {
            CommonLoggingInitializer.Initialize();
            Log = Common.Logging.LogManager.GetLogger(typeof(Program));
        }

        static void Main(string[] args)
        {
            Log.Info("Log using Common.Logging with Code Config");
        }
    }
}

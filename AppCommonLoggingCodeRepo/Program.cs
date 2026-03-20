using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCommonLoggingCode2
{
    internal class Program
    {
        static Common.Logging.ILog Log { get; }

        static Program()
        {
            LogInitializer.Initialize();
            Log = Common.Logging.LogManager.GetLogger(typeof(Program));
        }

        static void Main(string[] args)
        {
            Log.Info("Log using Common.Logging with log4net customize repository");
        }
    }
}

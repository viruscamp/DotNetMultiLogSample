using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppCommonLoggingConfig
{
    internal class Program
    {
        static Common.Logging.ILog Log { get; } = Common.Logging.LogManager.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            Log.Info("Log using Common.Logging");
        }
    }
}

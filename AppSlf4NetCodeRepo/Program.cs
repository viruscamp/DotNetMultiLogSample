using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSlf4NetCodeRepo
{
    internal class Program
    {
        static slf4net.ILogger Log { get; }

        static Program()
        {
            LogInitializer.Initialize();
            Log = slf4net.LoggerFactory.GetLogger(typeof(Program));
        }
        static void Main(string[] args)
        {
            Log.Info("Log using slf4net with log4net customize repository");
        }
    }
}

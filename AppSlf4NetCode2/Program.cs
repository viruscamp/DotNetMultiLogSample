using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSlf4NetCode2
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
            Log.Info("Log using slf4net with Code Config");
        }
    }
}

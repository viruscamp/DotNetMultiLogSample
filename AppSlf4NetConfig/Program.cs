using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppSlf4NetConfig
{
    internal class Program
    {
        static slf4net.ILogger Log { get; } = slf4net.LoggerFactory.GetLogger(typeof(Program));
        static void Main(string[] args)
        {
            Log.Info("Log using slf4net");
        }
    }
}

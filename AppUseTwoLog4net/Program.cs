using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppUseTwoLog4net
{
    internal class Program
    {
        static ILogger Log { get; } = LogManager.GetCurrentClassLogger();
        static void Main(string[] args)
        {
            Log.Info("Start use NLog");
            LibUseLog4net1210.Class1.Say();
            LibUseLog4net2017.Class1.Say();
            LibUseMEL.Class1.Say();
            Log.Error("End use NLog");
        }
    }
}

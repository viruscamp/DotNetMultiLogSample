using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibUseLog4net2017
{
    public class Class1
    {
        static ILog Log { get; } = LogManager.GetLogger(typeof(Class1));

        public static void Say()
        {
            Log.Info("Say log4net-2.0.17");
        }
    }
}

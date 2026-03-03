using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUseMEL
{
    public class Class1
    {
        private static ILogger<Class1> Log { get; } = Global.LoggerFactory.CreateLogger<Class1>();

        public static void Say()
        {
            Log.LogInformation("log with MEL");
        }
    }
}

using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibUseMEL
{
    public static class Global
    {
        public static ILoggerFactory LoggerFactory { get; set; }
    }
}

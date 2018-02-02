using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class LoggerFactory
    {
        public static ILogger CreateLogger() {
            return new TextFileLogger();
            // return new DatabaseLogger();
        }
    }
}

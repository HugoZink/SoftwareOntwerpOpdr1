using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class DatabaseLogger : ILogger
    {
        public void Log(string text)
        {
			Console.WriteLine("Logging the following to the database:");
			Console.WriteLine(text);
        }
    }
}

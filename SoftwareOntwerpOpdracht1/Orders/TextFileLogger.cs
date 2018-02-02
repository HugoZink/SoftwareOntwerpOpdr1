using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class TextFileLogger : ILogger
    {
        public void Log(string text)
        {
			var now = DateTime.Now;
			var dateString = $"{now.ToLongDateString()} {now.ToLongTimeString()}";

			using (StreamWriter w = File.AppendText("log.txt"))
			{
				w.WriteLine($"{dateString} {text}");
			}

			Console.WriteLine("Logged the following text to a log file:");
			Console.WriteLine(text);
		}
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class SMSMessage : IMessage
    {
        public void SendMessage(User user, string message)
        {
			Console.WriteLine("Writing the following SMS message to user: " + user.ToString());
			Console.WriteLine(message);
        }
    }
}

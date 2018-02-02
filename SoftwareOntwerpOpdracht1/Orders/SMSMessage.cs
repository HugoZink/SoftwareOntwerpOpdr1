using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    public class SMSMessage : IMessage
    {
        public void SendMessage(User user, string message)
        {
			Console.WriteLine("Writing the following SMS message to user: " + user.id);
			Console.WriteLine(message);
        }
    }
}

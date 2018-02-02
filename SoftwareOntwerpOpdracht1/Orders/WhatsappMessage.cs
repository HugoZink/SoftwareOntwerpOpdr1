using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class WhatsappMessage : IMessage
    {
        public void SendMessage(User user, string message)
        {
			Console.WriteLine("Writing the following WhatsApp message to user " + user.ToString());
			Console.WriteLine(message);
        }
    }
}

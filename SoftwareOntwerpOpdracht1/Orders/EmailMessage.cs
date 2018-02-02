using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    public class EmailMessage : IMessage
    {
        public void SendMessage(User user, string message)
        {
			Console.WriteLine("Writing the following email message to user " + user.id);
			Console.WriteLine(message);
        }
    }
}

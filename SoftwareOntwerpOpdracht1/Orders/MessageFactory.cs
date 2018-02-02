using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class MessageFactory
    {
        public static IMessage CreateMessage(User user)
		{
			switch(user.MessagePreference)
			{
				case "email":
					return new EmailMessage();
				case "sms":
					return new SMSMessage();
				case "whatsapp":
					return new WhatsappMessage();
				default:
					throw new ArgumentException("User's preference is unknown: " + user.MessagePreference);
			}
		}
    }
}

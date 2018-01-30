using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    public interface IOrder
    {
        string State { get; }

        IEnumerable<Ticket> Tickets { get; }
        IOrder Advance();
        IOrder Cancel();

		void AddTicket(Ticket ticket);
		void RemoveTicket(Ticket ticket);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    public class PendingOrder : IOrder
    {
		private List<Ticket> _tickets;

		public PendingOrder()
        {
            _tickets = new List<Ticket>();
        }

        public string State { get { return "Pending"; } }

		public IEnumerable<Ticket> Tickets
		{
			get
			{
				return _tickets;
			}
		}

		public IOrder Advance()
        {
            return new SubmittedOrder(_tickets);
        }

        public IOrder Cancel()
        {
            return new CanceledOrder(_tickets);
        }

		public void AddTicket(Ticket ticket)
		{
			this._tickets.Add(ticket);
		}

		public void RemoveTicket(Ticket ticket)
		{
			this._tickets.Remove(ticket);
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class SubmittedOrder : IOrder
    {
		private List<Ticket> _tickets;

		public SubmittedOrder(List<Ticket> tickets)
        {
            _tickets = tickets;
        }

        public string State { get { return "Submitted"; } }

		public IEnumerable<Ticket> Tickets
		{
			get
			{
				return _tickets;
			}
		}

		public IOrder Advance()
        {
            return new PaidOrder(_tickets);
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

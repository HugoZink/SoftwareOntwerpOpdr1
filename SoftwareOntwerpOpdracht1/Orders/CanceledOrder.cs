using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class CanceledOrder : IOrder
    {
		private List<Ticket> _tickets;

		public CanceledOrder(List<Ticket> tickets)
        {
            _tickets = tickets;
        }

        public string State { get { return "Canceled"; } }

		public IEnumerable<Ticket> Tickets
		{
			get
			{
				return _tickets;
			}
		}

		public IOrder Advance()
        {
            throw new InvalidOperationException();
        }

        public IOrder Cancel()
        {
            throw new InvalidOperationException();
        }

		public void AddTicket(Ticket ticket)
		{
			throw new InvalidOperationException();
		}

		public void RemoveTicket(Ticket ticket)
		{
			throw new InvalidOperationException();
		}
    }
}

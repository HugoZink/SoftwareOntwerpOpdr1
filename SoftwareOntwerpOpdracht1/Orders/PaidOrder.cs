using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class PaidOrder : IOrder
    {
        public PaidOrder(List<Ticket> tickets)
        {
            Tickets = tickets;
        }

        public string State { get { return "Paid"; } }

        public List<Ticket> Tickets { get; set; }

        public IOrder Advance()
        {
            throw new InvalidOperationException();
        }

        public IOrder Cancel()
        {
            throw new InvalidOperationException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class SubmittedOrder : IOrder
    {
        public SubmittedOrder(List<Ticket> tickets)
        {
            this.Tickets = tickets;
        }

        public string State { get { return "Submitted"; } }

        public List<Ticket> Tickets { get; set; }

        public IOrder Advance()
        {
            return new PaidOrder(Tickets);
        }

        public IOrder Cancel()
        {
            return new CanceledOrder();
        }
    }
}

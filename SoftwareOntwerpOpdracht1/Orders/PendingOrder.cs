using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class PendingOrder : IOrder
    {
        public PendingOrder()
        {
            Tickets = new List<Ticket>();
        }

        public string State { get { return "Pending"; } }

        public List<Ticket> Tickets { get; set; }

        public IOrder Advance()
        {
            return new SubmittedOrder(Tickets);
        }

        public IOrder Cancel()
        {
            return new CanceledOrder();
        }
    }
}

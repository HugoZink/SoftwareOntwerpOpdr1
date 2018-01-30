using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class CanceledOrder : IOrder
    {
        public CanceledOrder()
        {
            Tickets = new List<Ticket>();
        }

        public string State { get { return "Canceled"; } }

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

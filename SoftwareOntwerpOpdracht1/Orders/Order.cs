using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    public class Order 
    {
        public OrderState State { get; set; }
        private List<Ticket> _tickets;
        public IEnumerable<Ticket> Tickets { get { return _tickets; } }

        public Order()
        {
            this._tickets = new List<Ticket>();
        }
        
        public void AddTicket(Ticket ticket)
        {
            _tickets.Add(ticket);
        }

        public void RemoveTicket(Ticket ticket)
        {
            _tickets.Remove(ticket);
        }
    }
}

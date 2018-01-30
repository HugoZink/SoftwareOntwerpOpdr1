using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
	public class Order
	{
		public List<Ticket> Tickets { get; set; }

		public OrderStatus Status;

		public Order()
		{
			this.Tickets = new List<Ticket>();
			this.Status = OrderStatus.PENDING;
		}
	}
}

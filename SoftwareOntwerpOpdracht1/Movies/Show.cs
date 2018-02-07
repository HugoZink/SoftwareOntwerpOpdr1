using SoftwareOntwerpOpdracht1.Orders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Movies
{
	public class Show
	{
		private List<Order> _orders;

		public Movie Movie { get; set; }

		public Room Room { get; set; }

		public DateTime Date { get; set; }

		public IEnumerable<Order> Orders
		{
			get
			{
				return this._orders;
			}
		}

		public Show()
		{
			this._orders = new List<Order>();
		}

		public void AddOrder(Order order)
		{
			this._orders.Add(order);
		}

		public void RemoveOrder(Order order)
		{
			this._orders.Remove(order);
		}
	}
}

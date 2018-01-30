using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SoftwareOntwerpOpdracht1.Movies;

namespace SoftwareOntwerpOpdracht1.Orders
{
	public class User
	{
		public List<IOrder> Orders { get; private set; }

		public User()
		{
			this.Orders = new List<IOrder>();
		}
	}
}

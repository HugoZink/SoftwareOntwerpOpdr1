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
		public string id { get; private set; }
		public List<Order> Orders { get; private set; }
        public string MessagePreference { get; private set; } 

		public User(string preference)
		{
			this.id = Guid.NewGuid().ToString();

            this.MessagePreference = preference;
			this.Orders = new List<Order>();
		}
	}
}

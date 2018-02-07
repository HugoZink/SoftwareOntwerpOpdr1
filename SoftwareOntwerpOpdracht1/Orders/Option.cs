using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
	public abstract class Option
	{
		public abstract Decimal Price { get; }
		public abstract string Name { get; }
		public abstract int LimitPerPerson { get; }
	}
}

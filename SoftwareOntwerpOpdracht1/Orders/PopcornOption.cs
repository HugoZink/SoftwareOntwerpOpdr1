using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
	public class PopcornOption : Option
	{
		public override Decimal Price
		{
			get
			{
				return 2.0m;
			}
		}

		public override String Name
		{
			get
			{
				return "Popcorn";
			}
		}

		public override int LimitPerPerson
		{
			get
			{
				return 99;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
	public class BreakCateringOption : Option
	{
		public override Decimal Price
		{
			get
			{
				return 5.0m;
			}
		}

		public override String Name
		{
			get
			{
				return "Break Catering";
			}
		}

		public override int LimitPerPerson
		{
			get
			{
				return 1;
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
	public class ParkingOption : Option
	{
		public override Decimal Price
		{
			get
			{
				return 3.0m;
			}
		}

		public override String Name
		{
			get
			{
				return "Parking";
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

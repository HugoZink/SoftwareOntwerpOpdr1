using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class SubmittedOrder : OrderState
    {
        public override string State { get { return "Submitted"; } }

		public override bool CanManageTickets
		{
			get
			{
				return true;
			}
		}

		public override OrderState Cancel() {
            return new CanceledOrder();
        }

        public override OrderState Pay() {
            return new PaidOrder();
        }
    }
}

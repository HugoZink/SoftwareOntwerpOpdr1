using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    public abstract class OrderState
    {
        public abstract string State { get; }

		public virtual bool CanManageTickets {
			get
			{
				return false;
			}
		}

        public virtual OrderState Submit() { throw new InvalidOperationException(); }

        public virtual OrderState Cancel() { throw new InvalidOperationException(); }

        public virtual OrderState Pay() { throw new InvalidOperationException(); }
    }
}

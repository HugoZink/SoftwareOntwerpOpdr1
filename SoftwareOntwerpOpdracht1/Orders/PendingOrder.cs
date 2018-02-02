using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class PendingOrder : OrderState
    {
        public override string State { get { return "Pending"; } }

        public override OrderState Submit() {
            return new SubmittedOrder();
        }

        public override OrderState Cancel() {
            return new CanceledOrder();
        }
    }
}

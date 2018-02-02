using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    class OrderStateFactory
    {
        public static OrderState GetInitialOrder() { return new PendingOrder();  }
    }
}

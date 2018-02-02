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

        public override OrderState Cancel() {

        }

        public override OrderState Pay() {

        }

    }
}

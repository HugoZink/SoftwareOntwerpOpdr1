using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftwareOntwerpOpdracht1.Orders
{
    public interface IOrder
    {
        string State {get;}

        List<Ticket> Tickets { get; set; }
        IOrder Advance();
        IOrder Cancel();
    }
}

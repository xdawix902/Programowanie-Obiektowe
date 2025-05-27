using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Z1.TicketSeller;

namespace Z1
{
    interface ITicketSeller
    {
        string SellTicket(Ticket ticket, TicketSoldHandler handler);
    }
}

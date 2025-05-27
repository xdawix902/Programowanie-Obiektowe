using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public sealed class NormalTicket : Ticket
    {
        public NormalTicket(int ticketNumber, string matchName) : base(matchName, ticketNumber){}

        public override int GetPrice()
        {
            return 50;
        }
    }
}

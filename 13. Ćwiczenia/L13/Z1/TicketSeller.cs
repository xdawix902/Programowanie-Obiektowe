using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Z1
{
    public delegate void TicketSoldHandler(Ticket ticket);
    public sealed class TicketSeller : ITicketGetter, ITicketSeller
    {
        List<Ticket> ticketSold = new List<Ticket>();

        public string SellTicket(Ticket ticket, TicketSoldHandler handler)
        {
            if (ticketSold.Contains(ticket))
            {
                return "Bilet ten już został sprzedany!";
            }
            ticketSold.Add(ticket);
            handler?.Invoke(ticket);
            return $"Bilet numer {ticket.ticketNumber} na mecz {ticket.matchName} został sprzedany.";

        }

        public string GetTicketsSold()
        {
            return string.Join(Environment.NewLine, ticketSold.Select(t =>
                $"{t.ToString()} - cena: {t.GetPrice()} zł"
            ));
        }

        public string GetTicketsSoldOrdered()
        {
            List<Ticket> copy = new List<Ticket>(ticketSold);
            copy.Sort();
            return string.Join(Environment.NewLine, copy.Select(t =>
                $"{t.ToString()} - cena: {t.GetPrice()} zł"
            ));
        }

        public string GetTicketsSoldOrdered(IComparer<Ticket> comparer)
        {
            List<Ticket> copy = new List<Ticket>(ticketSold);
            copy.Sort(comparer);
            return string.Join(Environment.NewLine, copy.Select(t =>
                $"{t.ToString()} - cena: {t.GetPrice()} zł"
            ));
        }

        public override string ToString()
        {
            string odp = "";
            foreach(Ticket t in ticketSold)
            {
                odp += t.ToString() + "\n";
            }
            return odp;
        }
    }
}

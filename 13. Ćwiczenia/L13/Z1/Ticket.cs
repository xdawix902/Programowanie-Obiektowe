using System.Diagnostics;

namespace Z1
{
    public abstract class Ticket: IComparable<Ticket>
    {
        public string matchName;
        public int ticketNumber;

        public Ticket(string matchName, int ticketNumber)
        {
            this.matchName = matchName;
            this.ticketNumber = ticketNumber;
        }

        public int CompareTo(Ticket? other)
        {
            if (other == null) return 1;
            if(!(other is Ticket o))
            {
                throw new ArgumentException("Obiekt nie jest typem Ticket");
            }
            return ticketNumber.CompareTo(o.ticketNumber);
        }

        public override bool Equals(object obj)
        {
            if(obj != null && (obj is Ticket other))
            {
                return ticketNumber == other.ticketNumber;
            }
            return false;
            
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ticketNumber);
        }

        public override string ToString()
        {
            return $"Bilet numer {ticketNumber} na mecz {matchName}";
        }

        public abstract int GetPrice();

        public class TicketMatchNameComparer : IComparer<Ticket>
        {
            public int Compare(Ticket? x, Ticket? y)
            {
                if (x == null || y == null) return 0;

                return x.matchName.CompareTo(y.matchName);

            }
        }
    }
}

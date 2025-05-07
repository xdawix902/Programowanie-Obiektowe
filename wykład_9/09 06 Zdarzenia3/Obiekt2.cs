using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Zdarzenia
{
    class Obiekt2
    {
        public Obiekt2(CzasPlynie czasPlynie)
        {
            //czasPlynie.Subskrybenci += Raportuj; // stara wersja
            czasPlynie.Handler += ObslugaZdarzeniaLokalnaObiektu2; // wersja z nazwą zgodną z konwencą
            // mozna też odjąć
            //czasPlynie.Handler -= ObslugaZdarzeniaLokalnaObiektu2;
        }

        public void ObslugaZdarzeniaLokalnaObiektu2(Object? sender, CzasPlynieEventArgs args)
        // Obsługa ma sygnaturę zgodną z konwencją 
        {
            if (sender != null)
                Console.WriteLine($"Obserwator: {this}: {args.message}{args.currentTime}. Wywołujący: {sender}");
            else
                Console.WriteLine($"Obserwator: {this}: {args.message}{args.currentTime}. Wywołujący: nieznany");
        }
    }
}

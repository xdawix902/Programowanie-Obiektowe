using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdarzenia
{
    class Obiekt1
    {
        public Obiekt1(CzasPlynie czasPlynie)
        {
            // dodajemy metodę do subskrybentów!
            //czasPlynie.Subskrybenci += Raportuj; // stara wersja
            czasPlynie.Handler += ObslugaZdarzeniaLokalnaObiektu1; // wersja z nazwą zgodną z konwencjami
            // mozna też odjąć
            //czasPlynie.Handler -= ObslugaZdarzeniaLokalnaObiektu1;
        }

        public void ObslugaZdarzeniaLokalnaObiektu1(Object? sender, CzasPlynieEventArgs args)
        // ponieważ ujednolcono wywołanie, łatwo zrobić metody obsługi tego zdarzenia
        {
            if (sender != null)
                Console.WriteLine(
                    $"Obserwator: {this}: {args.message}{args.currentTime}. Wywołujący: {sender}"
                );
            else
                Console.WriteLine(
                    $"Obserwator: {this}: {args.message}{args.currentTime}. Wywołujący: nieznany"
                );
        }
    }
}

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
            czasPlynie.Subskrybenci += Raportuj;
            // mozna też odjąć
            //czasPlynie.Subskrybenci -= Raportuj;
        }
        //public void Raportuj(string msg)
        public void Raportuj(Object sender, CzasPlynieEventArgs args)
        {
            Console.WriteLine($"Obiekt1: {args.message}{args.currentTime}. Wywołujący: {sender.GetType}");
        }
    }
}

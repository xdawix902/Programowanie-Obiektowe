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
            czasPlynie.subskrybenci += Raportuj;
            // mozna też odjąć
            //czasPlynie.Subskrybenci -= Raportuj;

            // gdyby nie było słowa kluczowego event w klasie CzasPlynie,
            // to można by tutaj wywołać subskrybentów (a to nie ma sensu):
            //czasPlynie.subskrybenci("Obiekt 1 hola!");
        }
        public void Raportuj(string msg)
        {
            Console.WriteLine("Obiekt1: " + msg);
        }
    }
}

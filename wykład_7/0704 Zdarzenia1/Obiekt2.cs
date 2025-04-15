using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zdarzenia
{
    class Obiekt2
    {
        public Obiekt2(CzasPlynie czasPlynie)
        {
            czasPlynie.subskrybenci += Raportuj;
            // mozna też odjąć
            //czasPlynie.Subskrybenci -= Raportuj;
        }
        public void Raportuj(string msg)
        {
            Console.WriteLine("Obiekt2: " + msg);
        }
    }
}

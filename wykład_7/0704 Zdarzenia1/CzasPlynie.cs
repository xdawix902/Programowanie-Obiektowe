using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Zdarzenia
{
    public class CzasPlynie
    {
        // delegat jest reprezentatntem wszystkich funkcji subskrybowanych
        public delegate void OnEventCurrentTimeEven(string msg);

        // zwykła zmienna przechowuje referencję do delegata, słowo 'event' w ogóle nie występuje!
        public OnEventCurrentTimeEven subskrybenci;  // w trzecim kroku wykomentuj to

        // jeśli nie ma słowa 'event', to 'subskrybenci' musi być public i właściwości niemożliwe
        //private event OnEventCurrentTimeEven subskrybenci; // w trzecim kroku odkomentuj to
        /** /  // w trzecim kroku odkomentuj to
        // to są właściwości (jak get i set), ale specyficzne dla zdarzeń
        public event OnEventCurrentTimeEven Subskrybenci
        { 
            add    { subskrybenci += value; }
            remove { subskrybenci -= value; }
        }
        /**/
        // gdy to jest odkomentowane, to w plikach 'Obiekt1.cs', 'Obiekt2.cs'
        // zamiast 'subskrybenci' daj 'Subskrybenci' 

        public int currentTime;

        public CzasPlynie()
        {
            currentTime = 0;
        }

        public void UplywCzasu()
        {
            // niech obiekty obserwują czas i reagują, gdy czas jest parzysty
            while (currentTime < 10)
            {
                if ((currentTime % 2) == 0)
                {
                    Console.WriteLine(currentTime);
                    /**/ // w drugim kroku wykomentuj to
                    if (subskrybenci != null)
                        subskrybenci("aktualny czas " + currentTime + " jest parzysty");
                    /**/
                    //raiseEventCurrentTimeEven("aktualny czas " + currentTime + " jest parzysty"); // w drugim kroku odkomentuj to
                }
                System.Threading.Thread.Sleep(100);
                currentTime++;
            }
        }
        public void raiseEventCurrentTimeEven(string msg)
        {
            if (subskrybenci != null)
                // słowo event zapewnia, że tylko wewnątrz klasy można to wywołać
                // ma też dalsze zalety, np. związane z GUI
                subskrybenci(msg);
        }
    }
}

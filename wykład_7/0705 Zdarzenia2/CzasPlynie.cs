namespace Zdarzenia
{
    // wprowadzamy specjalną klasę do przekazywania argumentów do zdarzenia
    public class CzasPlynieEventArgs : EventArgs
    {   // te pola mogłyby być samej wklasie CzasPlynie, ale wtedy struktura programu byłaby dziwna
        public string message = "";
        public int currentTime = 0;
    }

    public class CzasPlynie
    {
        // delegat jest reprezentatntem wszystkich funkcji subskrybowanych
        public delegate void OnEventCurrentTimeIsEven(Object sender, CzasPlynieEventArgs args);
        // użyjemy prywatnego pola subskrybecni i właściwości Subskrybenci ją obsługującej
        private event OnEventCurrentTimeIsEven subskrybenci;
        public event OnEventCurrentTimeIsEven Subskrybenci
        {
            add    { subskrybenci += value; }
            remove { subskrybenci -= value; }
        }

        // pole może być teraz prywatne, bo komunikować się będziemy przez obiekt klasy CzasPlynieEventArgs
        private int currentTime;

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

                    // tworzymy obiekt zawierający argumenty
                    CzasPlynieEventArgs arguments = new CzasPlynieEventArgs();
                    arguments.currentTime = currentTime;
                    arguments.message = "Time is even: ";
                    raiseEventCurrentTimeIsEven(this, arguments);
                }
                System.Threading.Thread.Sleep(100);
                currentTime++;
            }
        }
        public void raiseEventCurrentTimeIsEven(Object sender, CzasPlynieEventArgs args)
        {
            //if (subskrybenci != null)
            //    subskrybenci(sender, args);

            // Zastosowanie typów "nullable" w parametrach wymaga od programisty
            // obsłużenia przypadków wartości null parametrów
            //if (sender != null && args != null)
            {
                subskrybenci?.Invoke(sender, args);
            }
        }
    }
}

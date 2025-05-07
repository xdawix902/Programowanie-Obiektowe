namespace Zdarzenia
{
    // wprowadzamy specjalną klasę do przekazywania argumentów do zdarzenia
    // która implementuje interfejs EventArgs
    public class CzasPlynieEventArgs : EventArgs
    {   // te pola mogłyby być samej wklasie CzasPlynie, ale wtedy struktura programu byłaby dziwna
        public string message = "";
        public int currentTime = 0;
    }

    public class CzasPlynie
    {
        //public delegate void EventHandler(object? sender, EventArgs e);
        //private event OnEventCurrentTimeIsEven subskrybenci; // zamienimy to na EventHandler subskrybenci
        // Zamiast tego:
        // skorzystamy ze standardowej deklaracji delegata obsługującego zdarzenia
        // w postaci obiektu klasy ogólnej EventHandler z parametrem <CzasPlynieEventArgs>
        private event EventHandler<CzasPlynieEventArgs>? subskrybenci;

        // na zewnątrz jest to właściwość, teraz w postaci handlera zdarzenia
        public event EventHandler<CzasPlynieEventArgs> Handler
        {
            add    { subskrybenci += value; }
            remove { subskrybenci -= value; }
        }

        // pole może być teraz prywatne, bo komunikować będziemy przez obiekt klasy CzasPlynieEventArgs
        private int currentTime;

        public CzasPlynie()
        {
            currentTime = 0;
        }
        public void UplywCzasu()
        {
            // przed pętlą tworzymy obiekt zawierający argumenty - można tak
            CzasPlynieEventArgs arguments = new CzasPlynieEventArgs();
            // niech obiekty obserwują czas i reagują, gdy czas jest parzysty
            while (currentTime < 10)
            {
                if ((currentTime % 2) == 0)
                {
                    Console.WriteLine("Current time is " + currentTime);
                    // korzystamy z wcześniej utoworzonego obiektu z arumentami
                    arguments.currentTime = currentTime;
                    arguments.message = "Time is even: ";
                    //RaiseEventCurrentTimeIsEven(this, arguments); 
                    // zmieniamy nazwę na bardziej typową
                    OnEventCurrentTimeIsEven(this, arguments);
                }
                System.Threading.Thread.Sleep(200);
                currentTime++;
            }
        }
        public void OnEventCurrentTimeIsEven(Object? sender, CzasPlynieEventArgs args)
        {
            //subskrybenci?.Invoke(sender, args); // wersja poprzednia

            // aby zaznaczyć, że subskrybenci to handler, można zrobić tak:
            // dwie linijki poniżej to nowa wersja
            EventHandler<CzasPlynieEventArgs>? LocalHandler = subskrybenci;
            LocalHandler?.Invoke(sender, args);
            // te dwie linijki mogłyby być równie dobrze wstawione
            // zamiast wywołania metody OnEventCurrentTimeIsEven() w pętli
            // w UplywCzasu - sprawa gustu.
            // Wtedy, deklarację LocalHandler można by umieścić przed pętlą
            // i tak dalej... W przykładach w Wykładzie 7 są takie wersje.
        }
    }
}

namespace Zdarzenia
{
    class Obiekt2
    {
        public Obiekt2(CzasPlynie czasPlynie)
        {
            czasPlynie.Subskrybenci += Raportuj;
            // mozna też odjąć
            //czasPlynie.Subskrybenci -= Raportuj;
        }
        public void Raportuj(Object sender, CzasPlynieEventArgs args)
        {
            Console.WriteLine($"Obiekt2: {args.message}{args.currentTime}. Wywołujący: {sender.GetType}");
        }
    }
}

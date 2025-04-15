using Zdarzenia;

internal class Program
{
    private static void Main(string[] args)
    {
        CzasPlynie czasPlynie = new CzasPlynie();
        Obiekt2 obiekt2 = new Obiekt2(czasPlynie);
        Obiekt1 obiekt1 = new Obiekt1(czasPlynie);

        // dzieje się coś w obiekcie tej klasy, obiekt1 i obiekt2 nasłuchują
        czasPlynie.UplywCzasu(); 
    }
}
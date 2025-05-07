internal class Program
{
    public class Ssak { }
    public class Pies : Ssak { }
    public delegate Ssak DTwórzSsaka(); // delegat zwraca Ssaka
    public delegate void DLeczPsa(Pies p); // delegat pobiera Psa

    public static Ssak TwórzSsaka() // metoda tworzy i zwraca Ssaka
    { Console.WriteLine("Twórz ssaka"); return new Ssak(); }
    public static Pies TwórzPsa() // metoda tworzy i zwraca Psa
    { Console.WriteLine("Twórz psa"); return new Pies(); }
    public static void LeczPsa(Pies p) // metoda pobiera Psa i leczy go 
    { Console.WriteLine("Lecz psa"); }
    public static void LeczSsaka(Ssak s) // metoda pobiera Ssaka i leczy go
    { Console.WriteLine("Lecz ssaka"); }

    private static void Main(string[] args)
    {
        Console.WriteLine("Kowariancja, kontrawariacja\n");

        DTwórzSsaka m1 = TwórzSsaka; // DTwórzSsaka i TwórzSsaka zwracają ssaka
        DTwórzSsaka m2 = TwórzPsa; // kowariancja: DTwórzSsaka zwraca ssaka a TwórzPsa - Psa  
        Ssak s = m2(); // korzystamy z wersji kowariantnej
 
        DLeczPsa l1 = LeczPsa; // DLeczPsa i LeczPsa pobierają Psa
        DLeczPsa l2 = LeczSsaka; // kontrawariancja: DLeczPsa pobiera psa a LeczSsaka - Ssaka
        l2(new Pies()); // korzystamy z wersji kontrawariantej
    }
}
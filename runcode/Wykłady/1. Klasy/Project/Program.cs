//using zad1;
//using zad2;
using zad3;
namespace Project;
class Program
{
    static void WyświetlOsobę(Osoba osoba){
        System.Console.WriteLine($"{osoba.Imie} {osoba.Nazwisko}");
        System.Console.WriteLine("Adres: ");
        WyświetlAdres(osoba.adres);
    }

    static void WyświetlAdres(Adres adres){
        System.Console.WriteLine(adres.ulica + " " + adres.numer);
    }
    static void Main(string[] args)
    {
        Adres a1 = new Adres();
        a1.ulica = "Mokra";
        a1.numer = 1;

        Adres a2 = new Adres();
        a2.ulica = a1.ulica;
        a2.numer = a1.numer;

        a1.numer = 34;
        
        Osoba o1 = new Osoba();
        o1.Imie = "Jan";
        o1.adres = a1;

        Osoba o2 = new Osoba();
        o2.Imie = "Marian";
        o2.adres = a2;
        
        Osoba o3 = o2;
        o3.Imie = "Elżbieta";
        o3.adres = a2;
        
        WyświetlOsobę(o1);
        WyświetlOsobę(o2);
        WyświetlOsobę(o3);
    }
}

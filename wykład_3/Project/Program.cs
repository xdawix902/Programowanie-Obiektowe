namespace Project;

class Osoba{
    public string Nazwisko;
    public long Pesel;
    public void Przedstaw(){
        System.Console.WriteLine(Nazwisko);
    }
}

class Student : Osoba{
    public int NumerIndeksu;
}
/* slajd 8
class Klasa{
    public int zmienna = 0;
}

class KlasaPotomna : Klasa{
    public new int zmienna = 1;
    
    public int getBazowaZmienna(){
        return base.zmienna;
    }

    public void setBazowaZmienna(int z){
        base.zmienna = z;
    }
}

class KlasaPotomnaKlasyPotomnej : KlasaPotomna{
    public new int zmienna = 2;
}
*/
/* slajd 11
class Klasa{
    public Klasa(){
        System.Console.WriteLine("Konstruktor Klasa.");
    }
}
class KlasaPotomna : Klasa{
    public KlasaPotomna(){
        System.Console.WriteLine("Konstruktor KlasaPotomna.");
    }
}
class KlasaPotomnaKlasyPotomnej : KlasaPotomna{
    public KlasaPotomnaKlasyPotomnej(){
        System.Console.WriteLine("Konstruktor KlasaPotomnaKlasyPotomnej.");
    }
}
*/

class Klasa{
    public Klasa(){
        System.Console.WriteLine("Konstruktor Klasa.");
    }
    public Klasa(int i){
        System.Console.WriteLine("Konstruktor Klasa z argumentem i = {0}",i);
    }
}
class KlasaPotomna : Klasa{
    public KlasaPotomna(){
        System.Console.WriteLine("Konstruktor KlasaPotomna.");
    }
    public KlasaPotomna(int i) : base(i){
        System.Console.WriteLine("Konstruktor KlasaPotomna z argumentem i = {0}",i);
    }
}

class Program
{
    static void Main(string[] args)
    {

        

        /* slajd 12
        KlasaPotomna klasaPotomna = new KlasaPotomna(2);
        */
        
        /* slajd 11
        KlasaPotomnaKlasyPotomnej klasaPotomnaKlasyPotomnej = new KlasaPotomnaKlasyPotomnej();
        */

        /* slajd 8
        Klasa klasa = new Klasa();
        KlasaPotomna klasaPotomna = new KlasaPotomna();
        System.Console.WriteLine(klasa.zmienna);
        System.Console.WriteLine(klasaPotomna.zmienna);
        System.Console.WriteLine(klasaPotomna.getBazowaZmienna());
        klasaPotomna.setBazowaZmienna(2);
        System.Console.WriteLine(klasaPotomna.getBazowaZmienna());
        System.Console.WriteLine(klasaPotomna.zmienna);
        */

        /* slajd 6 
        Student wieczny = new Student();
        wieczny.NumerIndeksu = 1000;
        wieczny.Nazwisko = "Smith";
        wieczny.Pesel = 1234;
        wieczny.Przedstaw();
        */
    }
}

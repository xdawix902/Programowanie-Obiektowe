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

class Bazowa{
    public Bazowa(int i, double d){
        System.Console.WriteLine("Bazowa");
    }
}

class Pochodna : Bazowa {
    public Pochodna(int i, double d) : base(i,d){
        System.Console.WriteLine("Pochodna");
    }
}

class Ryba {
    public void Plywaj(){
        System.Console.WriteLine("ryba lubi plywac");
    }
}
class Ptak {
    public void Spiewaj(){
        System.Console.WriteLine("spiewa ptak");
    }
}

class A{}
class B : A{}


class Program
{

    public int sampleMember;
    public void SampleMethod(){}
    static void Main(string[] args)
    {

        Type d = typeof(Program);
        System.Console.WriteLine("nazwa klasy: " +d.Name);

        Program obj = new Program();
        Type t = obj.GetType(); //inny sposób
        if(t == d){
            System.Console.WriteLine("Ta sama klasa");
        }
        System.Console.WriteLine(t.Name);
        System.Console.WriteLine(t.Namespace);
        System.Console.WriteLine(t.IsValueType);


        /* slajd 27
        Object a = new Ptak();
        Ptak b = a as Ptak;
        if(b == null) System.Console.WriteLine("To nie ptak");
        else b.Spiewaj();

        Object o = new Ryba();
        b = o as Ptak;
        if(b == null) System.Console.WriteLine("To nie ryba");
        else b.Spiewaj();
        */

        /* sjald 26
        A a = new A();
        B b = new B();

        if(a is A) System.Console.WriteLine("a jest A");
        if(b is A) System.Console.WriteLine("b jest pochodną A");
        if(a is B)
            System.Console.WriteLine("a jest pochodną B");
        else
            System.Console.WriteLine("a nie jest pochodną B");

        if(b is B) System.Console.WriteLine("b jest B");
        if(a is Object) System.Console.WriteLine("a to Object");
        */

        /* slajd 25
        Object a = new Ptak();
        Ptak b;

        if(a is Ptak){
            b = (Ptak) a;
            b.Spiewaj();
        }
        else System.Console.WriteLine("To nie ptak");

        Object o = new Ryba();

        if(o is Ptak){
            b = (Ptak) o;
            b.Spiewaj();
        }
        else System.Console.WriteLine("To nie ptak");
        */

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

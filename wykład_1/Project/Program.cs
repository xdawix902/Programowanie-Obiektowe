namespace Project;
class Pracownik{
    private string imie;
    private string nazwisko;
    private double pensja = 3000.0;

    public Pracownik(string imie, string nazwisko){
        System.Console.WriteLine("Konstruktor dwuagumentowy");
        this.imie = imie;
        this.nazwisko = nazwisko;
    }
    public Pracownik(string imie, string nazwisko, double pensja) : this(imie,nazwisko){
        System.Console.WriteLine("Konstruktor trzyargumeentowy");
        this.pensja = pensja;
    }
    public Pracownik() : this("Jan","Kowalski",1000.0){
        System.Console.WriteLine("Konstruktor zeroargumentowy");
    }

    public void PrintPracownika(){
        System.Console.WriteLine("imie: {0}\nnazwisko: {1}\npensja: {2}\n", imie, nazwisko,pensja);
    }
}
class Program
{
    static void Stringi(string x){
        x = "Ala nie ma kota";
    }
    static void AddOneByValue(int x){
        x = x + 1;
    }

    static void AddOneByReference(int[] x){
        x[0] = x[0] + 1;
    }
    static void Main(string[] args)
    {
        int y = 1;
        int[] z = [1];
        string t = "Ala ma kota";

        AddOneByValue(1);
        AddOneByReference(z);
        Stringi(t);
        
        System.Console.WriteLine(y);
        System.Console.WriteLine(z[0]);
        System.Console.WriteLine(t);

        Pracownik pracownik1 = new Pracownik();
        System.Console.WriteLine("\n");
        Pracownik pracownik2 = new Pracownik("Adam","WkładamISpadam");
        System.Console.WriteLine("\n");
        Pracownik pracownik3 = new Pracownik("Twoja","Mama",3902.45);
        System.Console.WriteLine("\n");

        pracownik1.PrintPracownika();
        pracownik2.PrintPracownika();
        pracownik3.PrintPracownika();

    }
}

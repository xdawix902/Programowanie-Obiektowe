namespace Program;

class Powitanie{
    public void Witam(){
        System.Console.WriteLine("Witam!!!");
    }

    public static void Czesc(){
        System.Console.WriteLine("Cześć!!!");
    }
    public void Specjalne(){
        System.Console.Write("Specjalne ");
        Czesc();
    }
}

class Bilet{
    public static int licznik = 0;
    public int numer;
    public Bilet(){
        numer = ++ licznik;
    }
    public static int IleWydano(){
        return licznik;
    }
}

class Testowa{
    public static int a;
    public int b;
    static Testowa(){
        a = 99;
        System.Console.WriteLine("Konstruktor static");
    }
    public Testowa(){
        b = 100;
        System.Console.WriteLine("Konstruktor instancji");
    }
    public static void Zmniejszenie(){
        a -= 1;
        System.Console.WriteLine(a);
    }
}

public class Singleton{
    private static Singleton obiekt = new Singleton();

    private Singleton(){
        //kod konstruktora, niedostępny w programie
    }
    public static Singleton ZwrocObiekt(){
        return obiekt;
    }
}

static class RozszerzenieDouble{
    public static double Potega(this double x, int n){
        double p = 1;

        for(int i = 0; i< (n < 0 ? -n : n); i++){
            p *= x;
        }
        return n < 0 ? 1/p : p;
    }
}

class SampleClass{
    public int x;
    public readonly int y = 25;
    public SampleClass(){
        y = 24;
    }
    public SampleClass(int v1, int v2){
        x = v1;
        y = v2;
    }
}

class ZampleClass{
    public const int c1 = 25;
    public const int c2 = c1+17;
}

class Student{
    private int numerIndeksu;
    public int NumerIndeksu{
        get {return numerIndeksu; }
        set {numerIndeksu = value; }
    }
}

class Cialo{
    private double temp;
    public double TempK{
        set{
            if(value >= 0) temp = value;
            else temp = 0;
        }
        get{
            return temp;
        }
    }

    public double TempC{
        set{
            temp = value + 273.15;
        }
        get{
            return temp - 273.15;
        }
    }
}

class A{
    public A(){
        System.Console.WriteLine("A's constructor");
    }
    ~A(){
        System.Console.WriteLine("A's finalizer");
    }
}

class Program
{
    static void Main(string[] args)
    {
        /* slajd 27
        A a = new A();
        a = null;
        System.GC.Collect();
        System.GC.WaitForPendingFinalizers();
        */
         
        /* slajd 24
        Cialo c = new Cialo();
        c.TempC = 100;
        System.Console.WriteLine(c.TempK);
        */

        /* slajd 23
        Student s = new Student();
        s.NumerIndeksu = 1234;
        int nr = s.NumerIndeksu;
        System.Console.WriteLine(s.NumerIndeksu);
        */

        /* slajd 20
        SampleClass p1 = new SampleClass(11,21);
        System.Console.WriteLine(p1.x + " " + p1.y);

        SampleClass p2 = new SampleClass();
        //p2.y = 999;
        System.Console.WriteLine(p2.x + " " + p2.y);
        */

        /* slajd 17
        double a = 2;
        System.Console.WriteLine(a.Potega(2));
        System.Console.WriteLine((2.0).Potega(-2));
        */

        /* slajd 16
        Singleton ob1 = Singleton.ZwrocObiekt();
        Singleton ob2 = Singleton.ZwrocObiekt();
        Singleton ob3 = new Singleton();
        */

        /* slajd 9
        Testowa obiekt1 = new Testowa();
        Testowa obiekt2 = new Testowa();
        System.Console.WriteLine("Testowa.a: " + Testowa.a);
        System.Console.WriteLine("obiekt.b: " + obiekt1.b);
        Testowa.Zmniejszenie();
        */

        /* slajd 7
        System.Console.WriteLine(Bilet.IleWydano());
        Bilet bilet = new Bilet();
        System.Console.WriteLine(bilet.numer);
        Bilet nowyBilet = new Bilet();
        Bilet jeszczeJedenBilet = new Bilet();
        System.Console.WriteLine(Bilet.IleWydano());
        */

        /* slajd 6
        Powitanie.Czesc();
        Powitanie p = new Powitanie();
        p.Witam();
        p.Specjalne();
        */
    }
}

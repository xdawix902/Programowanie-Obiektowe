namespace Project;

public delegate void TypDelegata();

public class Testowa{
    public static void Szczekaj(){
        System.Console.WriteLine("Hau hau");
    }
    public void Miaucz(){
        System.Console.WriteLine("Miau miau");
    }
}

public class Testowa2{
    private TypDelegata zmiennaDelegata3;
    public void ZwiazMetode(TypDelegata d){
        zmiennaDelegata3 = d;
    }
    public void WywolajZdelegowanaMetode(){
        zmiennaDelegata3();
    }
}

class Program
{
    static void Main(string[] args)
    {
        /* 5 slajd
        TypDelegata zmiennaDelegata = new TypDelegata(Testowa.Szczekaj);
        //TypDelegata zmiennaDelegata = Testowa.Szczekaj;
        zmiennaDelegata();

        TypDelegata zmiennaDelegata2;
        Testowa testowa = new Testowa();
        zmiennaDelegata2 = testowa.Miaucz;
        zmiennaDelegata2();
        */

        TypDelegata zmiennaDelegata = Testowa.Szczekaj;
        Testowa testowa = new Testowa();
        Testowa2 testowa2 = new Testowa2();

        //testowa2.ZwiazMetode(zmiennaDelegata);
        testowa2.ZwiazMetode(Testowa.Szczekaj);
        testowa2.WywolajZdelegowanaMetode();
        
    }
}

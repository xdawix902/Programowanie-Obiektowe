namespace Project;

//zad1
class Samochod{
    private int rokProdukcji;
    private string marka;
    private int predkoscMax;
    protected int PredkoscMax{
        get => predkoscMax;
    }
    protected int predkosc;

    public Samochod(int rokProdukcji, string marka, int predkoscMax, int predkosc){
        this.rokProdukcji = rokProdukcji;
        this.marka = marka;
        this.predkoscMax = predkoscMax;
        this.predkosc = predkosc;
    }
    public Samochod(int rokProdukcji, string marka, int predkoscMax) : this(rokProdukcji, marka,predkoscMax,0){}

    public string ZwrocInformacje(){
        return $"{this.marka} {this.rokProdukcji} Vmax = {this.predkoscMax} V = {predkosc}";
    }
}

class SamochodKierowany : Samochod {
    private string peselKierowcy;

    public SamochodKierowany(int rokProdukcji, string marka, int predkoscMax, int predkosc, string peselKierowcy)
        :base(rokProdukcji, marka, predkoscMax, predkosc){
            this.peselKierowcy = peselKierowcy;
    }
    
    public SamochodKierowany(int rokProdukcji, string marka, int predkoscMax, string peselKierowcy)
        :base(rokProdukcji, marka, predkoscMax){
            this.peselKierowcy = peselKierowcy;
    }

    public new string ZwrocInformacje(){
        return base.ZwrocInformacje() + $" {this.peselKierowcy}";
    }
    public void Przyspiesz(int oIle){
        if(this.predkosc + oIle < this.PredkoscMax){
            this.predkosc += oIle;
        }
        else{
            this.predkosc = this.PredkoscMax;
        }
        System.Console.WriteLine(this.predkosc);
    }
    public void Zwolnij(int oIle){
        if(this.predkosc > oIle){
            this.predkosc -= oIle;
        }
        else{
            this.predkosc = 0;
        }
        System.Console.WriteLine(this.predkosc);
    }
}

//zad2
class KontoBankowe{
    private int numerKonta;
    private string imieWlasciciela;
    private decimal saldo;

    public KontoBankowe(int numerKonta, string imieWlasciciela, decimal saldo){
        this.numerKonta = numerKonta;
        this.imieWlasciciela = imieWlasciciela;
        this.saldo = saldo;
    }
    public KontoBankowe(int numerKonta, string imieWlasciciela) 
        :this(numerKonta, imieWlasciciela, 0){}
    
    public virtual void Wplac(decimal kwota){
        this.saldo += kwota;
        System.Console.WriteLine($"Saldo wynosi: {this.saldo}");
    }

    public bool Wyplac(decimal kwota){
        if(this.saldo >= kwota){
            this.saldo -= kwota;
            return true;
        }
        return false;
    }
    public virtual string ZwrocInformacje(){
        return $"{this.numerKonta} {this.imieWlasciciela} {this.saldo}";
    }
}

class KontoOszczednosciowe : KontoBankowe{
    private decimal stopaProcentowa;
    public KontoOszczednosciowe(int numerKonta, string imieWlasciciela, decimal saldo, decimal stopaProcentowa)
        :base(numerKonta, imieWlasciciela, saldo){
            this.stopaProcentowa = stopaProcentowa;
    }
    public KontoOszczednosciowe(int numerKonta, string imieWlasciciela, decimal stopaProcentowa)
        :base(numerKonta, imieWlasciciela){
            this.stopaProcentowa = stopaProcentowa;
    }
    public KontoOszczednosciowe(int numerKonta, string imieWlasciciela)
        :base(numerKonta, imieWlasciciela){
            this.stopaProcentowa = 0;
    }


    public override void Wplac(decimal kwota)
    {
        base.Wplac(kwota * (1 + this.stopaProcentowa));
    }

    public override string ZwrocInformacje()
    {
        return base.ZwrocInformacje() + $" {this.stopaProcentowa}";
    }


}


class Program
{
    static void Main(string[] args)
    {
        /* zad1
        Samochod samochod1 = new Samochod(2001, "Opel", 100, 60);
        Samochod samochod2 = new Samochod(2013, "Volvo", 240);

        SamochodKierowany kierowca1 = new SamochodKierowany(2001, "Opel", 100, 65, "1234");
        SamochodKierowany kierowca2 = new SamochodKierowany(2013, "Volvo", 240, "123456");

        System.Console.WriteLine(samochod1.ZwrocInformacje());
        System.Console.WriteLine(samochod2.ZwrocInformacje());
        System.Console.WriteLine(kierowca1.ZwrocInformacje());
        System.Console.WriteLine(kierowca2.ZwrocInformacje());

        kierowca1.Przyspiesz(30);
        kierowca1.Zwolnij(10);
        kierowca1.Przyspiesz(50);
        kierowca1.Zwolnij(190);
        kierowca1.Przyspiesz(45);
        kierowca1.Przyspiesz(99);

        Samochod sk3 = new SamochodKierowany(2001,"Nissan", 190, "123324");
        System.Console.WriteLine(sk3.ZwrocInformacje());
        */
        
        KontoBankowe konto1 = new KontoBankowe(123456789, "Jan", 5000.00m);

        KontoOszczednosciowe konto2 = new KontoOszczednosciowe(987654321, "Anna", 10000.00m, 0.02m);

        Console.WriteLine(konto1.ZwrocInformacje());

        Console.WriteLine(konto2.ZwrocInformacje());

        konto1.Wplac(1000.00m);

        konto2.Wplac(2000.00m);

        Console.WriteLine(konto1.ZwrocInformacje());

        Console.WriteLine(konto2.ZwrocInformacje());

        konto1.Wyplac(500.00m);

        konto2.Wyplac(1000.00m);

        Console.WriteLine(konto1.ZwrocInformacje());

        Console.WriteLine(konto2.ZwrocInformacje());

        KontoBankowe konto3 = new KontoOszczednosciowe(987654321, "Anna", 10000.00m, 0.02m);

        konto3.Wplac(1000.00m);

        Console.WriteLine(konto3.ZwrocInformacje());
    }
}


//niby działa ale nie jestem pewien





namespace Zad2;

public interface IOperacyjny{
    void SetEventHandler(EventHandler<OperacjaEventArgs> handler);
    void Wplata(decimal kwota);
}

public enum TypOperacji{
    Wplata,
    Wyplata,
    Przelew
}

public class OperacjaEventArgs : EventArgs{
    public decimal kwota;
    public string typOperacji;

    public OperacjaEventArgs(string typOperacji, decimal kwota){
        this.kwota = kwota;
        this.typOperacji = typOperacji;
    }
}

public class OperacjaReceiverEventArgs : OperacjaEventArgs{
    public IOperacyjny odbiorca;
    
    public OperacjaReceiverEventArgs(decimal kwota, string typOperacji, IOperacyjny odbiorca) : base(typOperacji, kwota){
        this.odbiorca = odbiorca;
    }
}

public class Klient : IOperacyjny{
    string imie;
    string nazwisko;
    private decimal saldo = 0;

    public Klient(string imie, string nazwisko, decimal saldo){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.saldo = saldo;
    }
    public event EventHandler<OperacjaEventArgs> operacjaWykonana;

    //jest błąd
    public void Wplata(decimal kwota)
    {
        saldo += kwota;
        operacjaWykonana?.Invoke(this, new OperacjaEventArgs("Wpłata", kwota));
    }

    public void Wyplata(decimal kwota)
    {
        if (kwota > saldo)
        {
            throw new ArgumentException("Brak wystarczających środków na koncie.");
        }
        saldo -= kwota;
        operacjaWykonana?.Invoke(this, new OperacjaEventArgs("Wypłata", kwota));
    }

    public void Przelew(decimal kwota, IOperacyjny odbiorca)
    {
        Wyplata(kwota);
        odbiorca.Wplata(kwota);
        operacjaWykonana?.Invoke(this, new OperacjaReceiverEventArgs(kwota, "Przelew", odbiorca));
    }

    public void SetEventHandler(EventHandler<OperacjaEventArgs> handler){
        operacjaWykonana += handler;
    }

    public override string ToString()
    {
        return $"Klient: {GetHashCode()}";
    }
}   

public class Bank{
    private static Bank instance;
    public static Bank Instance => instance ??= new Bank();

    private Dictionary<IOperacyjny, List<OperacjaEventArgs>> historiaTransakcji = new();

    public static void ObslugaOperacji(object sender, OperacjaEventArgs operacja){
        if(sender is IOperacyjny klient){
            Bank inst = Instance;
            if(!inst.historiaTransakcji.ContainsKey(klient)){
                inst.historiaTransakcji[klient] = new List<OperacjaEventArgs>();
            }
            inst.historiaTransakcji[klient].Add(operacja);
        }
    }

    public void KonfiguracjaHistorii(Klient klient){
        klient.SetEventHandler(ObslugaOperacji);
    }

    public void WyswietlHistorie(IOperacyjny klient){
        System.Console.WriteLine($"\nHistoria transkacji klienta {klient}");

        if(historiaTransakcji.TryGetValue(klient, out var lista)){
            foreach(var operacja in lista){
                if(operacja is OperacjaReceiverEventArgs o){
                    System.Console.WriteLine($"{o.typOperacji} - {o.kwota} PLN do {o.odbiorca}");
                }
                else{
                    System.Console.WriteLine($"{operacja.typOperacji} - {operacja.kwota} PLN");
                }
            }
        }
        else{
            System.Console.WriteLine("Brak transakcji");
        }
    }
}


class Program
{
    static void Main(string[] args)
    {
        Bank bank = new Bank();

        Klient klient1 = new Klient("Jan", "Kowalski", 1000);

        Klient klient2 = new Klient("Janusz", "Tracz", 10000000);

        klient1.Wyplata(120);

        klient1.Wplata(10000);

        klient1.Przelew(1000, klient2);

        Console.WriteLine(bank);
    }
}

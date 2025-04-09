namespace Zad2;
public abstract class Zwierzę{
    string imie;
    public double waga;
    public Zwierzę(string imie, double waga){
        this.imie = imie;
        this.waga = waga;
    }
    public virtual void PrzedstawSie(){
        System.Console.WriteLine($"Imie: {imie}\nWaga:{waga}");
    }
}

class Kot : Zwierzę{
    double wysokość_skoku;
    public Kot(string imie, double waga, double wysokość_skoku) : base(imie, waga){
        this.wysokość_skoku = wysokość_skoku;
    }
    public override void PrzedstawSie()
    {
        base.PrzedstawSie();
        System.Console.WriteLine($"Wysokość skoku: {wysokość_skoku}");
    }
}

class Pies : Zwierzę{
    double długość_ogona;
    public Pies(string imie, double waga, double długość_ogona) : base(imie, waga){
        this.długość_ogona = długość_ogona;
    }
    public new void PrzedstawSie()
    {
        base.PrzedstawSie();
        System.Console.WriteLine($"Długość ogona: {długość_ogona}");
    }
}

public delegate void ModyfikujZwierze(Zwierzę z);
class Program
{
    public static void ZwiekszWage(Zwierzę z)
    {
        z.waga += 1;
    }

    public static void ZmniejszWage(Zwierzę z)
    {
        z.waga -= 1;
    }
    static void Main(string[] args)
    {
        Dictionary<string, Zwierzę> zwierzeta = new Dictionary<string, Zwierzę>
        {
            { "kotek", new Kot("Filemon", 3.5, 100) },
            { "piesek", new Pies("Burek", 12.0, 35) }
        };

        foreach (var para in zwierzeta)
        {
            Console.WriteLine($"Klucz: {para.Key}");
            para.Value.PrzedstawSie(); // używa wersji zgodnej z typem zmiennej — czyli Zwierze
            Console.WriteLine();
        }

        // Dodatkowo — rzutowanie, by wymusić wywołanie metody "new" z klasy Pies
        Console.WriteLine("Bezpośrednie rzutowanie na klasę Pies:");
        if (zwierzeta["piesek"] is Pies pies)
        {
            pies.PrzedstawSie(); // wywoła wersję przesłoniętą (new)
        }

        ModyfikujZwierze operacja = ZwiekszWage;
        if (zwierzeta.ContainsKey("Filemon"))
            operacja(zwierzeta["Filemon"]);

        operacja = ZmniejszWage;
        if (zwierzeta.ContainsKey("Burek"))
            operacja(zwierzeta["Burek"]);
    }
}

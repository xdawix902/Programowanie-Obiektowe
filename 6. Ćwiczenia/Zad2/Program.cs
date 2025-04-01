using System.Text;

namespace Zad2;

public delegate string Wybierz(PostacStarWars c);

public static class ListExtension<T>{
    public static string ZwrocInfoOListe(List<T> lista){
        if(lista == null) return "Lista jest null";
        if(lista.Count == 0) return "Lista jest pusta";

        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lista obiektów typu {typeof(T).Name} : ");

        foreach(var item in lista){
            if(item != null) sb.AppendLine(item.ToString());
        }
        return sb.ToString();
    }
}

public enum StronaKonfilktu{
    REPUBLIKA,
    IMPERIUM
}

public class PostacStarWars{
    string imie;
    string gatunek;
    public string plec;
    Planeta planetaMacierzysta;
    StronaKonfilktu stronaKonfilktu;

    public PostacStarWars(string imie, string gatunek, string plec, Planeta planetaMacierzysta, StronaKonfilktu stronaKonfilktu){
        this.imie = imie;
        this.gatunek = gatunek;
        this.plec = plec;
        this.planetaMacierzysta = planetaMacierzysta;
        this.stronaKonfilktu = stronaKonfilktu;
    }
    public PostacStarWars(PostacStarWars postac)
        :this(postac.imie, postac.gatunek, postac.plec, postac.planetaMacierzysta, postac.stronaKonfilktu){}

    public override string ToString()
    {
        return $"Imie: {imie}, Gatunek: {gatunek}, Planeta Macierzysta: {planetaMacierzysta}, Plec: {plec}, Strona Konfilktu: {stronaKonfilktu}";
    }
}

public class Planeta{
    string nazwa;
    uint? liczbaKsiezycow;

    public Planeta(string nazwa, uint? liczbaKsiezycow){
        this.nazwa = nazwa;
        this.liczbaKsiezycow = liczbaKsiezycow;
    }

    public Planeta(Planeta planeta)
        :this(planeta.nazwa, planeta.liczbaKsiezycow){}

    public override string ToString()
    {
        return $"Planeta {nazwa}, księżyce: {liczbaKsiezycow}";
    }
}

class PostacieStarWars{
    List<PostacStarWars> postacie = new List<PostacStarWars>();

    [Obsolete("Ta metoda jest przestarzała! Użyj ZwrocPostaciPo(Mybierz wybierz, string wartosc)", false)]
    public List<PostacStarWars> ZwrocPostaciPoPlci(string plec){
        List<PostacStarWars> nowa = new List<PostacStarWars>();

        foreach(var pos in postacie){
            if(pos.plec == plec){
                nowa.Add(new PostacStarWars(pos));
            }
        }
        return nowa;
    }
    public List<PostacStarWars> ZwrocPostaciPo(Wybierz wybierz, string wartosc){
        List<PostacStarWars> nowa = new List<PostacStarWars>();

        foreach(var postac in postacie){
            string wartoscPola = wybierz(postac);

            if(wartoscPola == wartosc){
                nowa.Add(new PostacStarWars(postac));
            }
        }
        return nowa;
    }
    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("Lista postaci: ");

        foreach(var postac in postacie){
            sb.AppendLine(postac.ToString());
        }
        return sb.ToString();
    }
    public void Dodaj(PostacStarWars postac){
        postacie.Add(postac);
    } 
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

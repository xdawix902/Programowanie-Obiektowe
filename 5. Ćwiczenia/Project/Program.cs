using System.Text;

namespace Project;

interface IKoszyk{
    void DodajDoKoszyka(Manga manga);
    void UsunZKoszyka(Manga manga);
}

class Manga{
    public string tytul;
    public string autor;
    public decimal cena;

    public Manga(string tytul, string autor, decimal cena){
        this.tytul = tytul;
        this.autor = autor;
        if(cena < 0) throw new ArgumentException();
        this.cena = cena;
    }

    public class MangaException : Exception{
        public MangaException(string message) : base("\t" + message){}
    }
}

class Sklep : IKoszyk{
    Manga[] mangi;
    public static int maksymalnyStanMagazynowy = 100;

    public Sklep(){
        mangi = new Manga[maksymalnyStanMagazynowy];
        mangi[0] = new Manga("Dragon Ball", "miass", 39.99m);
        mangi[1] = new Manga("Demon Slayer","Kaka", 29.99m);
    }
    public void KupMangi(Klient klient){
        System.Console.WriteLine("Kupiłeś Mangę/i !!");
        decimal suma = 0m;
        if(klient.koszyk.Length == 0) throw new Manga.MangaException("Koszyk klienta jest pusty!");
        for(int i = 0; i < klient.koszyk.Length; i++){
            Manga manga = klient.koszyk[i];
            suma += manga.cena;
            this.UsunZKoszyka(manga);
            klient.koszyk[i] = null;
        }
        System.Console.WriteLine("Suma: " + suma);
    }
    public void DodajDoKoszyka(Manga manga){
        for(int i = 0; i < mangi.Length; i++){
            if(mangi[i] == null){
                mangi[i] = manga;
                System.Console.WriteLine("Dodano mange");
                return;
            }
        }
        throw new Manga.MangaException("Przekroczono wielkość magazynu skelpu!");
    }
    public void UsunZKoszyka(Manga manga){
        for(int i = 0; i < mangi.Length; i++){
            if(manga.Equals(mangi[i])){
                System.Console.WriteLine("Usunięto");
                return;
            }
        }
        throw new Manga.MangaException("Nie znaleziono takiej mangi w sklepie!");
    }
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("Dostepne Mangi w sklepie: ");
        for(int i = 0; i < mangi.Length; i++){
            stringBuilder.AppendFormat($"{mangi[i].tytul} {mangi[i].autor} {mangi[i].cena}");
        }
        return(stringBuilder.ToString());
    }
}

class Klient : IKoszyk{
    public Manga[] koszyk;
    int liczbaMangWKoszyku;
    static int maksymalnyStanKoszyka = 3;
    Sklep sklep;
    public Klient(Sklep sklep){
        liczbaMangWKoszyku = 0;
        koszyk = new Manga[maksymalnyStanKoszyka];
    }
    public void DodajDoKoszyka(Manga manga){
        for(int i = 0; i < koszyk.Length; i++){
            if(koszyk[i] == null){
                koszyk[i] = manga;
                System.Console.WriteLine("Dodano");
                return;
            }
        }
        throw new Manga.MangaException("Koszyk jest już pełny.");
    }
    public void UsunZKoszyka(Manga manga){
        for(int i = 0; i<koszyk.Length; i++){
            if(koszyk[i].Equals(manga)){
                koszyk[i] = null;
                System.Console.WriteLine("Usunięto");
                return;
            }
        }
        throw new Manga.MangaException("Manga nie znajduje się w koszyku klienta");
    }
    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.AppendFormat("Mangi w koszyku klienta: ");
        for(int i = 0; i < koszyk.Length; i++){
            stringBuilder.AppendFormat($"{koszyk[i].tytul} {koszyk[i].autor} {koszyk[i].cena}");
        }
        return(stringBuilder.ToString());
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

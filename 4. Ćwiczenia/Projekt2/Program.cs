namespace Projekt2;

interface Iwypozyczalny{
    public void Wypozycz(Klient klient);
    public bool SprawdzDostepnosc();
}

abstract class Media : Iwypozyczalny{
    private string tytul;
    private string autor;
    private int rokWydania;
    decimal cena;

    public Media(string tytul, string autor, int rokWydania, decimal cena){
        this.tytul = tytul;
        this.autor = autor;
        this.rokWydania = rokWydania;
        this.cena = cena;
    }
    public void Wypozycz(Klient klient){
        System.Console.WriteLine("Wypożyczono " + this.tytul);
        klient.DodajMedia(this);
    }

    public virtual bool SprawdzDostepnosc(){
        return true;
    }
}

class Ksiazka : Media{
    private int liczbaStron;

    public Ksiazka(string tytul, string autor, int rokWydania, decimal cena, int liczbaStron)
        :base(tytul, autor, rokWydania, cena){
            this.liczbaStron = liczbaStron;
        }
}

class Ebook : Media{
    private int rozmiar;

    public Ebook(string tytul, string autor, int rokWydania, decimal cena, int rozmiar)
        :base(tytul, autor, rokWydania, cena){
            this.rozmiar = rozmiar;
        }
}

class Czasopismo : Media{
    public Czasopismo(string tytul, string autor, int rokWydania, decimal cena)
        :base(tytul, autor, rokWydania, cena) {}
    
    public override bool SprawdzDostepnosc(){
        return false;
    }
}

class Klient{
    private string imie;
    private string nazwisko;
    Media[] wypozyczoneMedia = new Media[maksymalnaLiczbaWypozyczen];
    public static int maksymalnaLiczbaWypozyczen = 3;

    public Klient(string imie, string nazwisko){
        this.imie = imie;
        this.nazwisko = nazwisko;
    }
    public int IloscWypozyczonychMediow{
        get{return policzMedia();}
    }
    private int policzMedia(){
        int licznik = 0;
        for(int i = 0; i < maksymalnaLiczbaWypozyczen; i++){
            if(wypozyczoneMedia[i] != null) licznik++;
        }
        return licznik;
    }
    public void DodajMedia(Media media){
        for(int i = 0; i < maksymalnaLiczbaWypozyczen; i++){
            if(wypozyczoneMedia[i] != null){
                wypozyczoneMedia[i] = media;
                System.Console.WriteLine("Dodano obiekt");
                break;
            }
        }
        System.Console.WriteLine("Nie ma miejsca");
    }

}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

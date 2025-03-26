namespace Project;

class Osoba{
    string imie;
    string nazwisko;

    public string Imie{
        get{
            return imie + "****"; 
        }
        set{
            if(value.Length < 3){
                throw new Exception("Imie dłuższe od 3");
            }
            imie = value;
        }
    }
    public string Nazwisko { get => nazwisko; set => nazwisko = value;}

    public Osoba(string imie, string nazwisko){
        this.imie = imie;
        this.nazwisko = nazwisko;
    }
    public string ZwrocOsobe(){
        return $"{imie} {nazwisko}";
    }
}


class Program
{
    static void Main(string[] args)
    {
        Osoba osoba = new Osoba("Jan","Kowalski");
        System.Console.WriteLine(osoba.ZwrocOsobe());
        System.Console.WriteLine(osoba.Imie);
        try{
            osoba.Imie = "Ja";
        }
        catch{
            System.Console.WriteLine("Dłuższe imie dawaj");
        }
        System.Console.WriteLine(osoba.ZwrocOsobe());
    }
}

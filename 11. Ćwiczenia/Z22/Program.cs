namespace Z22;

public class Osoba{
    public string Imie;
    public int Wiek;
    public string Nazwisko{ get; set;}

    public Osoba(string imie, string nazwisko, int wiek){
        this.Imie = imie;
        this.Wiek = wiek;
        this.Nazwisko = nazwisko;
    }

    public void UstawWiek(int wiek){
        this.Wiek = wiek;
    }

    public string ZwrocPelneImie(){
        return $"{this.Imie} {this.Nazwisko}";
    }

    public int ZwrocWiek(){
        return this.Wiek;
    }
}

public class Samochod{
    public string Marka;
    public int RokProdukcji;
    public string Model{get; set;}

    public Samochod(string marka, string model, int rokProdukcji){
        this.Marka = marka;
        this.Model = model;
        this.RokProdukcji = rokProdukcji;
    }

    public void UstawRokProdukcji(int rokProdukcji){
        this.RokProdukcji = rokProdukcji;
    }

    public string ZwrocMarkeModel(){
        return $"{this.Marka} {this.Model}";
    }

    public int ZwrocRokProdukcji(){
        return this.RokProdukcji;
    }
}

public static class ListHelper{
    public static void Wyswietl(this List<string> list){
        foreach(var c in list){
            System.Console.WriteLine(c);
        }
    }
}

public static class ObjectReflector{
    public static List<string> GetFieldNames(object obj){
        List<string> ans = new List<string>();
        var pola = obj.GetType().GetFields();

        foreach(var c in pola){
            ans.Add(c.Name);
        }
        return ans;
    }

    public static List<string> GetMethods(object obj){
        List<string> ans = new List<string>();
        var pola = obj.GetType().GetMethods();

        foreach(var c in pola){
            ans.Add(c.Name);
        }
        return ans;
    }

    public static List<string> GetPropertyNames(object obj){
        List<string> ans = new List<string>();
        var pola = obj.GetType().GetProperties();

        foreach(var c in pola){
            ans.Add(c.Name);
        }
        return ans;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Osoba o = new Osoba("Paweł", "Kowalski", 25);
        Console.WriteLine("Pola klasy Osoba:");
        ObjectReflector.GetFieldNames(o).Wyswietl();
        Console.WriteLine("Właściwości klasy Osoba:");
        ObjectReflector.GetPropertyNames(o).Wyswietl();
        Console.WriteLine("Metody klasy Osoba:");
        ObjectReflector.GetMethods(o).Wyswietl();
        
        Console.WriteLine();
        Samochod s = new Samochod("Izera", "Elektryczna", 2999);
        Console.WriteLine("Pola klasy Samochod:");
        ObjectReflector.GetFieldNames(s).Wyswietl();
        Console.WriteLine("Właściwości klasy Samochod:");
        ObjectReflector.GetPropertyNames(s).Wyswietl();
        Console.WriteLine("Metody klasy Samochod:");
        ObjectReflector.GetMethods(s).Wyswietl();
            }
}

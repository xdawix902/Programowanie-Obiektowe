namespace Program;

class Osoba1{
    string imie;
    string nazwisko;
    public Osoba1(string imie, string nazwisko){
        this.imie = imie;
        this.nazwisko = nazwisko;
    }
    public Osoba1(string nazwisko){
        this.imie = "";
        this.nazwisko = nazwisko;
    }
    public Osoba1(){
        imie = "**";
        nazwisko = "***";
    }
}

class Pojazd{
    string marka;
    string model;

    public Pojazd(string marka){
        this.marka = marka;
    }
    public Pojazd(string marka, string model)
        :this(marka){
        this.model = model;
    }
    public Pojazd()
        :this("Fiat","Duży"){
        }
    public void ZwrocPojazd(){
        System.Console.WriteLine($"{marka} {model}");
    }
}

class Osoba2{
    string imie;
    string nazwisko;
    Adres adres;
    
    public Osoba2(){
        System.Console.WriteLine("Jednoargumentowy");
        this.adres = new Adres("Konwaliowa","Warszawa");
    }
    public Osoba2(string imie, string nazwisko)
        :this(){
        System.Console.WriteLine("Dwuargumentowy");
        this.imie = imie;
        this.nazwisko = nazwisko;
    }

    public void ZwrocOsobe(){
        System.Console.WriteLine($"{imie} {nazwisko}, adres: {adres.ZwrocAdres()}");
    }
}

class Adres{
    string ulica;
    string miasto;
    public Adres(){
        this.ulica = "";
        this.miasto = "";
    }
    public Adres(string ulica, string miasto){
        this.ulica = ulica;
        this.miasto = miasto;
    }
    public Adres(Adres adres){
        this.ulica = adres.ulica;
        this.miasto = adres.miasto;
    }
    public void ZmienUlica(){
        this.ulica = "Różana";
    }
    public string ZwrocAdres(){
        return $"{ulica} {miasto}";
    }
}


class Osobba{
    string imie;
    string nazwisko;
    Adres adres;
    public Osobba(string imie, string nazwisko, Adres adres){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.adres = new Adres(adres);
    }
    public Osobba(Osobba osoba){
        this.imie = osoba.imie;
        this.nazwisko = osoba.nazwisko;
        this.adres = new Adres(osoba.adres);
    }
    public Osobba Kopiuj(){
        Osobba kopia = new Osobba(this.imie, this.nazwisko, this.adres);
        return kopia;
    }
    public void ZmienImie(){
        this.imie = "***";
        adres.ZmienUlica();
    }
    public string ZwrocOsobe(){
        return $"{imie} {nazwisko}, adres: {adres.ZwrocAdres()}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        /* 1. film
        Osoba1 o1 = new Osoba1("Jan", "Kowalski");
        Osoba1 o2 = new Osoba1("Ela","Kowalska");
        Osoba1 o3 = new Osoba1("Nowak");
        Osoba1 o4 = new Osoba1();
        */
        /* 2. film
        Pojazd p1 = new Pojazd("Fiat");
        p1.ZwrocPojazd();
        Pojazd p2 = new Pojazd("Fiat","Maluch");
        p2.ZwrocPojazd();
        Pojazd p3 = new Pojazd();
        p3.ZwrocPojazd();
        */
        /* 3. film
        Osoba2 o1 = new Osoba2("Jan","Kowalski");
        o1.ZwrocOsobe();
        */
        
        Adres adres = new Adres("Konwaliowa","Warszawa");
        Osobba o1 = new Osobba("Jan", "Kowalski", adres);
        
        Osobba o2 = o1.Kopiuj();
        

        
        o1.ZmienImie();

        System.Console.WriteLine(o1.ZwrocOsobe());
        System.Console.WriteLine(o2.ZwrocOsobe());
    }
}

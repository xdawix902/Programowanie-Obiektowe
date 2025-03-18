namespace Project;

abstract class Zwierze{
    string nazwa;
    float waga;
    float wysokosc;

    public Zwierze(string nazwa, float waga, float wysokosc){
        this.nazwa = nazwa;
        this.waga = waga;
        this.wysokosc = wysokosc;
    }
    public virtual void Jedz(float wartosc){
        this.waga += wartosc;
    }   
    public abstract string PoruszajSie();
    public override string ToString(){
        return $"Nazwa: {this.nazwa}\nWaga: {this.waga}kg\nWysokość: {this.wysokosc}\n";
    }
}

class Kot : Zwierze{
    private int liczbaWyskokow;
    private int liczbaNawrotow;
    public Kot(string nazwa, float waga, float wysokosc, int liczbaWyskokow, int liczbaNawrotow) :base(nazwa,waga,wysokosc){
        this.liczbaWyskokow = liczbaWyskokow;
        this.liczbaNawrotow = liczbaNawrotow;
    }
    public override void Jedz(float wartosc){
        base.Jedz(wartosc);
        System.Console.WriteLine("Kot zjadł posiłek");
    }
    public override string PoruszajSie(){
        return "Kot porusza sie";
    }
    public override string ToString()
    {
        return base.ToString() + $"Liczba Wyskokow: {this.liczbaWyskokow}\nLiczba Nawrotow: {this.liczbaNawrotow}\n";
    }
}

class Kon : Zwierze{
    private int liczbaPrzyspieszen;
    private int liczbaSpowolnien;
    public Kon(string nazwa, float waga, float wysokosc, int liczbaPrzyspieszen, int liczbaSpowolnien) 
        :base(nazwa, waga, wysokosc){
            this.liczbaPrzyspieszen = liczbaPrzyspieszen;
            this.liczbaSpowolnien = liczbaSpowolnien;
        }
    public override void Jedz(float wartosc){
        base.Jedz(wartosc);
        System.Console.WriteLine("Kon zjadl");
    }
    public override string PoruszajSie(){
        return "Kon porusza sie";
    }
    public override string ToString(){
        return base.ToString() + $"Liczba Przyspieszen: {this.liczbaPrzyspieszen}\nLiczba Spowolnien: {this.liczbaSpowolnien}\n";
    }
}

class BazaZwierrzat{
    Zwierze[] zwierzeta = new Zwierze[5];
    static int i = 0;
    public void DodajZwierze(Zwierze zwierze){
        for(int i = 0; i < zwierzeta.Length; i++){
            if(zwierzeta[i] != null){
                zwierzeta[i] = zwierze;
                System.Console.WriteLine("Dodano zwierze");
                break;
            }
        }
        System.Console.WriteLine("Nie ma miejsca");
    }
    public void UsunZwierze(Zwierze zwierze){
        for(int i = 0; i < zwierzeta.Length; i++){
            if(zwierzeta[i] == zwierze){
                zwierzeta[i] = null;
                System.Console.WriteLine("Usunieto zwierze");
                break;
            }
        }
        System.Console.WriteLine("Nie ma takiego zwierzecia");
    }
    private string ZwrocZwierzeta(){
        for(int i = 0; i < zwierzeta.Length; i++){
            System.Console.WriteLine(zwierzeta[i]);
        }
    }
    public void WszystkieZwierzetaJedza(float wartosc){
        for(int i = 0; i < zwierzeta.Length; i++){
            zwierzeta[i].Jedz(wartosc);
        }
        System.Console.WriteLine("Wszystkie zwierzeta zjadly");
    }
    public void WszystkieZwierzetaPoruszajaSie(){
            for(int i = 0; i < zwierzeta.Length; i++){
            zwierzeta[i].PoruszajSie()
        }
        System.Console.WriteLine("Wszystkie zwierzeta zjadly");
    }
    public override string ToString(){
        return this.ZwrocZwierzeta();
    }


}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

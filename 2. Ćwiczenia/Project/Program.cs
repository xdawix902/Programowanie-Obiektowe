
namespace Project;

public class Geometria{
    public const double Pi = 3.14;
    public const double PierwiastekZTrzech = 1.732050807568877;

    public static double PoleKola(double promien){
        return Pi*promien*promien;
    }
    public static double ObwodKola(double promien){
        return 2*Pi*promien;
    }
    public static double PoleProstokata(double a, double b){
        return a * b;
    }
    public static double ObwodProstokata(double a, double b){
        return 2*a + 2*b;
    }
    public static double PoleTrojkataRownobocznego(double a){
        return a*a*PierwiastekZTrzech / 4.0;
    }
    public static double ObwodTrojkataRownobocznego(double a){
        return 3*a;
    }
}

public class Student{
    public string imie;
    public string nazwisko;
    public string numerAlbumu;
    private GlosZaGraCounterStrike counterstrike;
    private GlosZaLeagueOfLegends leagueOfLegends;

    public Student(string imie, string nazwisko, string numerAlbumu){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.numerAlbumu = numerAlbumu;

    }

    public void ZaglosujZaGraLeagueOfLegends(){
        if(counterstrike != null){
            System.Console.WriteLine("Ten uczen zaglosowal na cs'ka");
            return;
        }
        leagueOfLegends = new GlosZaLeagueOfLegends();
    }
    public void ZaglosujZaGraCounterStrike(){
        if(leagueOfLegends != null){
            System.Console.WriteLine("Ten uczen zaglosowal na lola");
            return;
        }
        counterstrike = new GlosZaGraCounterStrike();
    }
}
public class GlosZaGraCounterStrike{
    private static uint ileGlosow;
    public GlosZaGraCounterStrike(){
        ileGlosow++;
    }
    public uint ZwrocIloscGlosow(){
        return ileGlosow;
    }
    public static void IleGlosow(){
        System.Console.WriteLine($"Na CS'a jest: {ileGlosow} glosow");
    }
}

public class GlosZaLeagueOfLegends{
    private static uint ileGlosow;
    public GlosZaLeagueOfLegends(){
        ileGlosow++;
    }
    public uint ZwrocIloscGlosow(){
        return ileGlosow;
    }
    public static void IleGlosow(){
        System.Console.WriteLine($"Na Lol'a jest: {ileGlosow} glosow");
    }
}

class Program
{
    static void Main(string[] args)
    {  
        /* zadanie 1
        System.Console.WriteLine(Geometria.Pi);
        //przykłady dla każdej funkcji */
        
        while(true){
            System.Console.Write("Podaj imie studenta: ");
            string imie = Console.ReadLine();

            if(imie == "KONIEC") break;

            System.Console.Write("Podaj nazwisko studenta: ");
            string nazwisko = Console.ReadLine();

            System.Console.WriteLine("Podaj indeks studenta: ");
            string album = Console.ReadLine();

            string glos;
            while(true){
                System.Console.Write("Na co glosuje? (C- cs, L- lol): ");
                glos = Console.ReadLine();
                if(glos == "C" || glos == "L"){
                    break;
                }
                System.Console.WriteLine("Błąd");
            }
            Student student = new Student(imie,nazwisko,album);

            if(glos == "C"){
                student.ZaglosujZaGraCounterStrike();
            }
            else{
                student.ZaglosujZaGraLeagueOfLegends();
            }
        }
        GlosZaGraCounterStrike.IleGlosow();
        GlosZaLeagueOfLegends.IleGlosow();
        //nie robiłem testów ale powinno działać na logike
    }
}

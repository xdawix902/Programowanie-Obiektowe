using System.Text;

namespace Zad1;

public class CzłonekZespołu : IComparable{
    string imie;
    string nazwisko;
    int wiek;

    public CzłonekZespołu(string imie, string nazwisko, int wiek){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.wiek = wiek;
    }

    public int CompareTo(object? obj){
        if(obj == null) return 1;
        if(!(obj is CzłonekZespołu other)){
            throw new ArgumentException("Obiekt nie jest typem CzłonekZepsołłu");
        }
        return wiek.CompareTo(other.wiek);
    }

    public class CzłonekZespołuPoNazwiskuComparer : IComparer<CzłonekZespołu>{
        public int Compare(CzłonekZespołu x, CzłonekZespołu y){
            if(x == null || y == null) return 1;

            if(!(x is CzłonekZespołu pX) || !(y is CzłonekZespołu pY)){
                throw new ArgumentException("Obiekt nie jest typu CzłonekZespołu");
            }
            return pX.nazwisko.CompareTo(pY.nazwisko);
        }

    }
    public override string ToString()
    {
        return $"{imie} {nazwisko} {wiek}";
    }

}


class Program
{
    public static string ListToString<T>(List<T> lista){
            StringBuilder sb = new StringBuilder();
            foreach(T element in lista){
                sb.AppendLine(element?.ToString());
            }
            return sb.ToString();
        }
    static void Main(string[] args)
    {
        CzłonekZespołu JohnBonham = new CzłonekZespołu("John", "Bonham",32);

        CzłonekZespołu RobertPlant = new CzłonekZespołu("Robert", "Plant", 73);

        CzłonekZespołu JimmyPage = new CzłonekZespołu("Jimmy", "Page", 77);

        CzłonekZespołu JohnPaulJones = new CzłonekZespołu("John Paul", "Jones", 75);

        List<CzłonekZespołu> ledZeppelin = new List<CzłonekZespołu> { JohnBonham, RobertPlant, JimmyPage, JohnPaulJones };

        System.Console.WriteLine(ListToString<CzłonekZespołu>(ledZeppelin));

        ledZeppelin.Sort(); // po wieku

        System.Console.WriteLine(ListToString<CzłonekZespołu>(ledZeppelin));
        ledZeppelin.Sort(new CzłonekZespołu.CzłonekZespołuPoNazwiskuComparer());
        System.Console.WriteLine(ListToString<CzłonekZespołu>(ledZeppelin));

    }
}

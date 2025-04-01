using System.Text;

namespace Zad1;

public delegate void Akcja<T>(T t);

class Student : IComparable<Student>{
    public string imie;
    public string nazwisko;
    public int numerIndeksu;
    public int rokStudiow;

    public Student(string imie, string nazwisko, int numerIndeksu, int rokStudiow){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.numerIndeksu = numerIndeksu;
        this.rokStudiow = rokStudiow;
    }
    public Student(Student student){
        this.imie = student.imie;
        this.nazwisko = student.nazwisko;
        this.numerIndeksu = student.numerIndeksu;
        this.rokStudiow = student.rokStudiow;
    }
    public override string ToString()
    {
        return $"student {this.imie} {this.nazwisko} rok {this.rokStudiow} indeks numer:{this.numerIndeksu}";
    }
    public bool Equals(Student other){
        if(this != null && other != null){
            return this.numerIndeksu == other.numerIndeksu;
        }
        return false;
    }
    public override int GetHashCode()
    {
        return this.numerIndeksu.GetHashCode();
    }
    public int CompareTo(Student other){
        if(other == null) return 1;
        return numerIndeksu.CompareTo(other.numerIndeksu);
    }

    class StudentPoNazwiskoAsCComparer : IComparer<Student>{
        public int Compare(Student x, Student y){
            if(x == null || y == null) return 0;
            return x.nazwisko.CompareTo(y.nazwisko);
        }
    }

    class StudentPoRokStudiowDESCComparer : IComparer<Student>{
        public int Compare(Student x, Student y){
            if(x == null || y == null) return 0;
            return y.rokStudiow.CompareTo(x.rokStudiow);
        }
    }

    public class ZarzadzanieException : Exception{
        public ZarzadzanieException(string message) : base(message){}
    }

    class Zarzadzanie<T>{
        List<T> zarzadzani;

        public Zarzadzanie(List<T> zarzadzani){
            this.zarzadzani = zarzadzani;
        }
        public int? PodajPozycje(T t){
            if(t == null){
                throw new ZarzadzanieException("Przekazano do metody PodajPozycje null!");
            }
            int index = zarzadzani.IndexOf(t);
            return index >= 0 ? index : (int?) null;
        }
        public void Sortuj(){
            if(zarzadzani == null) throw new ZarzadzanieException("Nie można posortować pustej lub niezainicjalizowanej listy!");
            zarzadzani.Sort();
        }
        public void Sortuj<U>(U u) where U : IComparer<T>{
            if(zarzadzani == null) throw new ZarzadzanieException("Nie można posortować pustej lub niezainicjalizowanej listy!");
            zarzadzani.Sort(u);
        }
        public void Modyfikuj(Akcja<T> akcja){
            if(akcja == null) throw new ZarzadzanieException(nameof(akcja));
            foreach(T element in zarzadzani){
                akcja(element);
            }
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Zarządzane:");
            foreach(T element in zarzadzani){
                if(element != null) sb.Append(element.ToString());
            }
            return sb.ToString();
        }
    }
    
}   


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
    }
}

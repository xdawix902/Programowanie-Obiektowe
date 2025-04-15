using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Z1;

class ListaNaSterydach<T> : List<T>{

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        Enumerator e = this.GetEnumerator();
        int i = 0;
        while(e.MoveNext()){
            sb.AppendLine($"{i++}: {e.Current?.ToString() ?? null}");
        }
        return sb.ToString();
    }
}

class Osoby : IEnumerable{
    ListaNaSterydach<Osoba> listaOsob;

    public Osoby(ListaNaSterydach<Osoba> listaOsob){
        this.listaOsob = listaOsob;
    }

    public IEnumerator GetEnumerator()
    {
        return new OsobyEnumerator(listaOsob);
    }

    private class OsobyEnumerator : IEnumerator
    {
        ListaNaSterydach<Osoba> listaOsob;
        int currentIndex = -1;
        public OsobyEnumerator(ListaNaSterydach<Osoba> listaOsob){
            this.listaOsob = listaOsob;
        }
        public object Current => listaOsob[currentIndex];

        public bool MoveNext()
        {
            currentIndex++;
            return currentIndex < listaOsob.Count;
        }

        public void Reset()
        {
            currentIndex = -1;
        }
    }
}

class Osoba{
    string imie;
    string nazwisko;
    int? wiek;

    public Osoba(string imie, string nazwisko, int? wiek){
        this.imie = imie;
        this.nazwisko = nazwisko;
        this.wiek = wiek;
    }
    public Osoba(string imie, string nazwisko) : this(imie,nazwisko,null){}

    public object this[int index]{
        get{
            switch (index){
                case 0: return imie;
                case 1: return nazwisko;
                case 2: return wiek?.ToString() ?? "";
                default: throw new ArgumentOutOfRangeException("Nieprawidłowy indeks. Dostępne indeksy: 0 (imię), 1 (nazwisko), 2 (wiek)");
            }
        }
    }
    public override string ToString()
    {
        if(wiek != null) return $"{imie} {nazwisko} {wiek}";
        return $"{imie} {nazwisko}";
    }

    public static explicit operator string(Osoba c){
        return c.ToString();
    }

    public static implicit operator Osoba(string c){
        string[] lista = c.Split(' ');
        if(lista.Length < 2){
            throw new Exception("Za mało wartości");
        }
        else if(lista.Length == 2){
            return new Osoba(lista[0], lista[1]);
        }
        else{
            int age;
            if(int.TryParse(lista[2], out age)){
                return new Osoba(lista[0], lista[1], age);
            }
            return new Osoba(lista[0],lista[1]);
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
Osoba osoba1 = new Osoba("Jan", "Kowalski", 25);
Osoba osoba2 = new Osoba("Anna", "Nowak", 30);
Osoba osoba3 = new Osoba("Piotr", "Zalewski", 22);
 
ListaNaSterydach<Osoba> listaOsob = new ListaNaSterydach<Osoba> {osoba1, osoba2, osoba3};
Console.WriteLine(listaOsob);
 
string s1 = "Mariusz Lewandowski";
string s2 = "Robert Lewandowski 15";
 
Osoba o1 = s1;
Console.WriteLine(o1);
 
Osoba o2 = s2;
Console.WriteLine(o2);
 
string s3 = (string)osoba1;
Console.WriteLine(s3);
 
Console.WriteLine("\tExcel:");
string[,] tabelkaExcela = new string[3, 3];
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        tabelkaExcela[i, j] = (string)listaOsob[i][j];
    }
}
 
for (int i = 0; i < 3; i++)
{
    for (int j = 0; j < 3; j++)
    {
        Console.Write(tabelkaExcela[i,j] + " ");
    }
    Console.WriteLine();
}
 
Osoba o3 = "Sławomir Peszko 0.7";
Console.WriteLine(o3);
    }
}
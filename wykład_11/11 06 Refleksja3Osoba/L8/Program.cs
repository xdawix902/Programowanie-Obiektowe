using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace L8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Osoba osoba1 = new Osoba("Jan", "Kowalski", 25);
            Osoba osoba2 = new Osoba("Anna", "Nowak", 30);
            Osoba osoba3 = new Osoba("Piotr", "Zalewski", 22);
            osoba3.Przekwalifikowanie("Ogrodnik", 2023);

            ListaNaSterydach<Osoba> listaOsob = new ListaNaSterydach<Osoba> { osoba1, osoba2, osoba3 };
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
                    tabelkaExcela[i, j] = listaOsob[i][j];
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

            Osoba o3 = "Sławomir Peszko 41";
            Console.WriteLine(o3);
        }
    }

    class Osoby : IEnumerable
    {
        private ListaNaSterydach<Osoba> listaOsob;

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new OsobyEnumerator(listaOsob);
        }

        private class OsobyEnumerator : IEnumerator
        {
            private List<Osoba> listaOsob;
            private int currentIndex = -1;

            public OsobyEnumerator(List<Osoba> listaOsob)
            {
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

    class ListaNaSterydach<T> : List<T>
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Enumerator e = this.GetEnumerator();
            while (e.MoveNext())
            {
                sb.AppendLine(e.Current.ToString());
            }
            return sb.ToString();
        }
    }

    class Osoba
    {
        private string imię, nazwisko;
        private int? wiek;
        public string zawod = "Bez zawodu";
        public int odKiedy = 0;

        public Osoba(string imię, string nazwisko, int? wiek)
        {
            this.imię = imię;
            this.nazwisko = nazwisko;
            this.wiek = wiek;
        }

        public Osoba(string imię, string nazwisko) : this(imię, nazwisko, null) { }

        public void Przekwalifikowanie(string nowyZawod, int odKtoregoRoku)
        {
            this.zawod = nowyZawod;
            this.odKiedy = odKtoregoRoku;
        }

        // Operator explicit konwersji na typ string (explicit ponieważ w ramach konwersji jest ona stratna - tracimy wiek!)
        public static explicit operator string(Osoba osoba)
        {
            return $"{osoba.imię} {osoba.nazwisko}";
        }

        public static implicit operator Osoba(string str)
        {
            string[] parts = str.Split(" ");
            if (parts.Length == 3) 
            {
                try
                {
                    return new Osoba(parts[0], parts[1], int.Parse(parts[2]));
                }
                catch (FormatException)
                {
                    throw new ArgumentException("Niepoprawny format imienia, nazwiska i wieku. Oczekiwany format: 'Imię Nazwisko Wiek'.\n Wiek w postaci liczby całkowitej!");
                }
            }
            else if (parts.Length != 2) 
                throw new ArgumentException("Niepoprawny format imienia i nazwiska. Oczekiwany format: 'Imię Nazwisko'.");
            else 
                return new Osoba(parts[0], parts[1]);
        }

        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return imię;
                    case 1:
                        return nazwisko;
                    case 2:
                        return wiek.ToString();
                    default:
                        throw new ArgumentOutOfRangeException("Niepoprawny indeks. Dostępne indeksy: 0 - imię, 1 - nazwisko, 2 - wiek.");
                }
            }
        }

        public override string ToString()
        {
            return $"Osoba: {imię} {nazwisko} {wiek} {zawod} {odKiedy}";
        }
    }
}

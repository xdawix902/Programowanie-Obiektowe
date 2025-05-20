using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L12
{
    public class CzłonekZespołu : IComparable
    {
        string imie;
        string nazwisko;
        int wiek;

        public CzłonekZespołu(string imie, string nazwisko, int wiek)
        {
            if (string.IsNullOrWhiteSpace(imie))
                throw new ArgumentException("Imię nie może być puste");
            if (string.IsNullOrWhiteSpace(nazwisko))
                throw new ArgumentException("Nazwisko nie może być puste");
            if (wiek < 0)
                throw new ArgumentOutOfRangeException("Wiek nie może być ujemny");
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.wiek = wiek;
        }

        public int CompareTo(object? obj)
        {
            if (obj == null) return 1;
            if (!(obj is CzłonekZespołu other))
            {
                throw new ArgumentException("Obiekt nie jest typem CzłonekZepsołłu");
            }
            return wiek.CompareTo(other.wiek);
        }

        public class CzłonekZespołuPoNazwiskuComparer : IComparer<CzłonekZespołu>
        {
            public int Compare(CzłonekZespołu x, CzłonekZespołu y)
            {
                if (x == null || y == null) return 1;

                if (!(x is CzłonekZespołu pX) || !(y is CzłonekZespołu pY))
                {
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
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace Lambda
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lambda - Lista");

            // to jest niezbędne, nie wykomentowywać
            var lista = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            // Metoda Where() z biblioteki Linq jest metodą rozszerzającą (wykł. 2)
            // Działanie: enumerowalnyObiekt.Where(Bool warunek)
            var posredniaLista = lista.Where((element) => { return element > 5; });
            //var posredniaLista = lista.Where(e => e > 5);

            // posredniaLista nie jest typu Lista, sprawdzamy to
            Type t = posredniaLista.GetType();
            // więc ją przekształcamy na listę obiektów typu int
            List<int> nowaLista = posredniaLista.ToList<int>();
            // albo prościej, typ wynika z konstrukcji prawej strony
            //var nowaLista = posredniaLista.ToList<int>();

            // A teraz wszystko w jednej linii kodu, bez pośredniej linii
            // - wykomentuj powyższe linie za wyjątkiem generowaania listy
            //var nowaLista = lista.Where(zmienna => zmienna > 5).ToList<int>();

            foreach (var liczba in nowaLista)
                Console.WriteLine(liczba);
        }
    }
}

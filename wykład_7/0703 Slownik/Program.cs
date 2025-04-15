using System;
using System.Collections.Generic;

namespace Slownik
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Słownik!");

            // dwa parametry <klasa, klasa>: klucz (najlepiej jak indeks) i wartość (jak tekst)
            Dictionary<int, string> slownik = new Dictionary<int, string>();
            // konstruktor przeciążony

            slownik.Add(2, "Jaś"); // indeksy nie muszą być po kolei
            slownik.Add(4, "Małgosia");

            if (!slownik.ContainsKey(4)) // jedna z właściwości
                slownik.Add(4, "Jaga"); // byłby błąd wykonania
            slownik.Add(12, "Jaga"); // OK

            foreach (var item in slownik)
            {  // item typu var jest parą: Key, Value - najedź kursorem na var
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }

            // jak z innymi kolekcjami, istnieje wiele użytecznych metod i właściwości
        }
    }
}

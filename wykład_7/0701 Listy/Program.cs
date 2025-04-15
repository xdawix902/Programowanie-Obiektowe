using System;
using System.Collections;
using System.Collections.Generic;

namespace Listy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Listy!");

            ArrayList lista = new ArrayList();

            lista.Add(3.7);
            lista.Add("Wyraz");
            SomeClass konik = new SomeClass("Jagon");
            lista.Add(konik);

            Console.WriteLine(lista.Count);
            lista.Remove("Wyraz"); // inteligentnie usuwa element, porządkuje listę
            Console.WriteLine(lista.Count);

            // klasa ArrayList dostarcza liczne metody wpisywania, zmieniania, usuwania elementów listy

            foreach (var item in lista) // var to znaczy taki typ, jaki będzie mieć aktualny item
            {  // Zakłada się, że istnieje IEnumerator w klasie, do ktorej należy lista
                int index = lista.IndexOf(item);
                Console.WriteLine("["+index+"] "+item);
            }
            lista.Reverse();
            foreach (var item in lista) {
                int index = lista.IndexOf(item);
                Console.WriteLine("[" + index + "] " + item);
            }

            lista.Insert(1, 7);
            foreach (var item in lista)
            {
                int index = lista.IndexOf(item);
                Console.WriteLine("[" + index + "] " + item);
            }

            lista.Clear(); // łatwo się domyślić co robi

            // istnieje zwykła lista, wszystkie elementy są tego samego typu
            List<int> listaInt = new List<int>();
            // ...
        }
    }

    public class SomeClass
    {
        public string nazwa;
        public SomeClass(string nazwa)
        {
            this.nazwa = nazwa;
        }
        public override string ToString()
        {  // żeby nie zwracało nazwy klasy, tylko nazwy obiektu
            return nazwa;
        }
    }

}

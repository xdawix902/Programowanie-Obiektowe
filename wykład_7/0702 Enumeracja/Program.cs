using System;
using System.Collections;

namespace Enumeracja
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enumeracja");

            // Tworzymy instancję kolekcji
            MyCollection collection = new MyCollection();

            // Przykład użycia pętli foreach do iteracji po elementach kolekcji
            foreach (var item in collection)
            {
                Console.WriteLine(item);
            }
        }
    }
    public class MyCollection : IEnumerable
    {
        // przykładowa prościutka kolekcja z prościutką inicjalizacją
        private int[] items = new int[3];
        public MyCollection()
        {
            items[0] = 1; items[1] = 2; items[2] = 3;
        }
        public IEnumerator GetEnumerator()
        {   // Musimy przygotować metodę GetEnumerator, która tworzy
            // obiekt klasy, która z kolei musi mieć trzy metody
            // Current(), MoveNext() i Reset() - ta klasa jest dalej
            // Implementacja metody GetEnumerator() ("obiecana" w interfejsie IEnumerable)
            return new MyEnumerator(items); // konstruktor klasy ma naszą tablicę obiektów jako parametr
        }
        private class MyEnumerator : IEnumerator
        { // Klasa iteratora zagnieżdżona w naszej nowej kolekcji
            private int[] items;
            private int currentIndex = -1;
            public MyEnumerator(int[] items)
            {
                this.items = items;
            }
            public Object Current { 
                get 
                {
                    int returnValue = items[currentIndex];
                    return returnValue; 
                } 
            }
            //public Object Current => items[currentIndex];

            public bool MoveNext()
            {
                currentIndex++;
                bool returnValue = currentIndex < items.Length;
                return returnValue;
            }
            public void Reset()
            {
                currentIndex = -1;
            }
        }
    }
}

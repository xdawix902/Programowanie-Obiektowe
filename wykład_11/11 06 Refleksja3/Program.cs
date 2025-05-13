using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly a = null;
        string plikDLL = "L8.dll"; // Lab 8 Zad 1 z modyfikacjami
        a = Assembly.LoadFrom(plikDLL);
        Type typ = a.GetType("L8.Osoba");

        // wywołamy konstruktor klasy "Osoba"
        object obj = Activator.CreateInstance(typ, "Leszek", "Chmielewski", 18);
        
        MethodInfo mi = typ.GetMethod("ToString");
        string s = (string)mi.Invoke(obj, null);
        Console.WriteLine(s);

        // przygotowujemy parametry dla metody "Przekwalifikowanie", zawsze jako tablica obiektów
        object[] parametry = new object[2]; 
        parametry[0] = "Marynarz";
        parametry[1] = 2024;
        
        mi = typ.GetMethod("Przekwalifikowanie"); // Osoba ma taką metodę, dwa parametry: "Zawód", rok
        mi.Invoke(obj, parametry); // wywołujemy tę metodę, uwaga na sygnaturę
        
        mi = typ.GetMethod("ToString");
        s = (string)mi.Invoke(obj, null);
        Console.WriteLine(s);
    }
}
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Assembly a = Assembly.LoadFrom("L8.dll"); // Lab 8 Zad 2
        Type[] types = a.GetTypes();
        int i = 0;
        foreach (Type t in types)
        {
            Console.WriteLine("    Type {0}/{1}:", ++i, types.Length);
            Console.WriteLine("Name: {0}", t.FullName);
            Console.WriteLine("Namespace: {0}", t.Namespace);
            Console.WriteLine("Base is: {0}", t.BaseType);
            Console.WriteLine("Is it abstract? {0}", t.IsAbstract);
            Console.WriteLine("Is it a COM object? {0}", t.IsCOMObject);
            Console.WriteLine("Is it sealed? {0}", t.IsSealed);
            Console.WriteLine("Is it a class? {0}", t.IsClass);
            Console.WriteLine("Is it value type? {0}", t.IsValueType);
        }
    }
}
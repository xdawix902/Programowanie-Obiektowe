public class NaszTestAttribute : Attribute
// atrybut musi dziedzicyć po klasie Atribute
{
    bool b;
    public NaszTestAttribute(bool argument)
    { b = argument; }
    public bool B()
    { return b; }
}

[NaszTestAttribute(false)]
public class Klasa { } 
// pusta klasa jest opisana atrybutem NaszTestAttribute
public class Test
{
    private static void Main(string[] args)
    {
        Console.WriteLine("atrybuty Klasa to: ");
        // używamy metody Attribute.GetCustomAttribute(typ klasy) do pobrania atrybutów
        object[] aAttributes = Attribute.GetCustomAttributes(typeof(Klasa));
        foreach (object attr in aAttributes)
        {
            // będzie tylko jeden atrybut: NaszTestAttribute
            Console.Write(attr);
            // jego metoda B() zwróci wartość
            Console.WriteLine(" " + ((NaszTestAttribute)attr).B());
        }
    }
}
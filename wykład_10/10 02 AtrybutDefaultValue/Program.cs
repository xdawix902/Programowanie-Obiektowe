using AtrybutDefaultValue;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Atrybut DefaultValue");

        TestowanieAtrybutu testowanieAtrybutu = new TestowanieAtrybutu();
        //testowanieAtrybutu.DzienTygodnia = "Inny"; // przez własność DzienTygodnia podstawiamy lub nie
     
        // przygotowujemy dane do pobrania atrybutu
        Type type = typeof(TestowanieAtrybutu); // pytamy co to za klasa (inaczej: jaki typ ma obiekt)
        var property = type.GetProperty("DzienTygodnia"); // bierzemy właściwość DzienTygodnia z tej klasy
        Type attributeType = typeof(DefaultDayofWeekAttribute); // bierzemy typ atrybutu, o którym jest ten przykład
        
        // używamy metody Attribute.GetCustomAttribute(własność, typ atrybutu) do pobrania atrybutu
        var attribute = (DefaultDayofWeekAttribute)Attribute.GetCustomAttribute(property, attributeType);

        // we właściwości Value atrybutu spodziewamy się tej wartości domyślnej
        Console.WriteLine("Default day of week from attribute: {0}", attribute.Value);

        // we właściwości obiektu klasy spodziwamy się wartości rzeczywiście nadanej
        Console.WriteLine("Actual day of week in the object: {0}", testowanieAtrybutu.DzienTygodnia);

        // Jeśli nie nadalismy wartości, to nie ma wartości, choć jest nadany atrybut.
        // Atrybut możemy nadać i zapisać w nim wartość, ale do nas należy zadbanie o to, co z nim zrobimy.
    }
}
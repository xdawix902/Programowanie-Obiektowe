using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("JSON Serializing");
        Product product = new Product();
        product.name = "Konfitura";
        product.price = 12;
        product.ExpiryDate = new DateTime(2008, 12, 28);
        product.ExpiryDate = new DateTime(2008, 12, 28);

        JsonSerializer serializer = new JsonSerializer();
        // własności JsonSerializer - dodajemy konwerter daty
        serializer.Converters.Add(new JavaScriptDateTimeConverter());
        // ustalamy, jak mają być traktowane wartości null
        serializer.NullValueHandling = NullValueHandling.Ignore;
        // itd. ...

        using (StreamWriter sw = new StreamWriter("tmp.txt"))
        // kierujemy wyjście z JsonTextWriter do utworzonego pliku
        using (JsonWriter writer = new JsonTextWriter(sw))
        {
            // serializujemy i zapisujemy obiekt
            serializer.Serialize(writer, product);
            // {"price":12,"name":"Konfitura","ExpiryDate":new Date(1230418800000)}
        }

        Product newProduct = new Product();
        using (StreamReader sr = new StreamReader("tmp.txt"))
        using (JsonReader reader = new JsonTextReader(sr))
        {
            newProduct = serializer.Deserialize<Product>(reader);
        }
        Console.WriteLine("Nowy produkt: {0}, {1}, {2}.", 
            newProduct.name, newProduct.price, newProduct.ExpiryDate);
    }

    public class Product
    {
        //private int price; // źle - Json nie zapisuje prywatnych pól
        public int price;
        public string name;
        public DateTime ExpiryDate;
    }
}
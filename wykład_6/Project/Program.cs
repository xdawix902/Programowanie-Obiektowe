namespace Project;

public class KlasaOgraniczona<T>{
    public static int Count = 0;
    private T nr;
    public KlasaOgraniczona(T i){
        nr = i;
        Count++;
    }
    public T Nr{
        get{
            return nr;
        }
    }
}
class Program
{
    static void Main(string[] args)
    {
        KlasaOgraniczona<int> klasaOgraniczonaInt1 = new KlasaOgraniczona<int>(1);
        KlasaOgraniczona<int> klasaOgraniczonaInt2 = new KlasaOgraniczona<int>(2);
        KlasaOgraniczona<double> klasaOgraniczonaDouble = new KlasaOgraniczona<double>(1.0);

        System.Console.WriteLine(KlasaOgraniczona<int>.Count);
        System.Console.WriteLine(KlasaOgraniczona<double>.Count);
    }
}

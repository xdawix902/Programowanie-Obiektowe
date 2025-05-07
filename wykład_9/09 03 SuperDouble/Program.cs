
internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("SuperDouble");

        double a = 2;
        Console.WriteLine(a.Potega(-2));
        Console.WriteLine((2.0).Potega(-2));

        // odwołajmy się do Potega() jak do składowej klasy statycznej
        Console.WriteLine(SuperDouble.Potega(2.0, -3));
    }
}

static class SuperDouble
{
    public static double Potega(this double x, int n)
    {
        double p = 1;
        for (int i = 0; i < (n < 0 ? -n : n); i++)
            p *= x;
        return n < 0 ? 1 / p : p;
    }
}

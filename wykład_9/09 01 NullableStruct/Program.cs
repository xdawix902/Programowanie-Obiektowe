internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Nullable struct");
        Point p = new Point(6, 11);
        Point? nullablePoint = new Point(5, 10);
        Console.WriteLine("p.x: {0}", p.x);
        Console.WriteLine("p.y: {0}", p.y);
        Console.WriteLine("nullablePoint.x: {0}", nullablePoint.Value.x);
        Console.WriteLine("nullablePoint.y: {0}", nullablePoint.Value.y);
        //Console.WriteLine("nullablePoint.y: {0}", nullablePoint.y); // błąd kompilacji
        //Point = null;  // błąd kompilacji
        nullablePoint = null; // w porządku
        // teraz należałoby obsłużyć przypadek nul, ale tego nie zrobiono
        //Console.WriteLine("nullablePoint.y: {0}", nullablePoint.Value.y); // błąd wykonania

        // poprzedni przykład z wykładu, rozszerzony
        int? e = null; int? f = null; int? g = null; int? h = null; 
        int fin = -1;
        // g = e, ale jeśli e==null to g = f, jeśli także f==null to g = -1 
        int i = e ?? f ?? g ?? h ?? fin; // można dać wiele argumentów, ostatni musi być non-nullable
        Console.WriteLine("Now i = {0}.", i);
        i = g.GetValueOrDefault();
        Console.WriteLine("Finally i = {0}.", i);
    }
    struct Point
    {
        public int x; public int y;
        public Point(int xVal, int yVal)
        {
            x = xVal; y = yVal;
        }
    }

}
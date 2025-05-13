internal class Program
{
    private static void Main(string[] args)
    {
        string path1 = @"c:\temp\MyTest.txt";
        string path2 = @"c:\temp\MyTest";
        string path3 = @"temp";

        if (Path.HasExtension(path1))
        {
            Console.WriteLine("{0} ma rozszerzenie.", path1);
        }

        if (!Path.HasExtension(path2))
        {
            Console.WriteLine("{0} nie ma rozszerzenia.", path2);
        }

        if (Path.IsPathRooted(path2))
        {
            Console.WriteLine("{0} ma root.", path2);
        }
        if (!Path.IsPathRooted(path3))
        {
            Console.WriteLine("{0} nie ma root.", path3);
        }

        Console.WriteLine("pełna sciezka {0} to {1}.", path3, Path.GetFullPath(path3));
        Console.WriteLine("{0} tutaj sa pliki tymczasowe.", Path.GetTempPath());
        Console.WriteLine("{0} to tymczasowy plik do użytku.", Path.GetTempFileName());
    }
}
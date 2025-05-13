internal class Program
{
    public static long DirSize(DirectoryInfo d)
    {
        long Size = 0;
        FileInfo[] fis = d.GetFiles();
        long fisLength = fis.Length;
        for (int i = 0; i < fisLength; i++)
            Size += fis[i].Length;

        DirectoryInfo[] dis = d.GetDirectories();
        long disLength = dis.Length;
        for (int k = 0; k < disLength; k++)
            Size += DirSize(dis[k]);
        return Size;
    }
    
    private static void Main(string[] args)
    {
        string myPath = @"C:\Users\dawid\Desktop\ProgObiek";
        DirectoryInfo d = new DirectoryInfo(myPath);
        
        Console.WriteLine("Rozmiar \"{0}\" i jego podkatalogów: {1} bajtow.", d, DirSize(d));
    }
}
namespace TestAnol1;

class Program
{   

    [Obsolete("Use meMeth2, instead.")]
    static int myMeth(int a, int b){
        return a/b;
    }
    static int myMeth2(int a, int b){
        return b == 0 ? 0 : a/b;
    }

    static void Main(string[] args)
    {
        //System.Console.WriteLine("4 / 3 is " + Program.myMeth(4,3));
        System.Console.WriteLine("4 / 3 is " + Program.myMeth2(4,3));
    }
}

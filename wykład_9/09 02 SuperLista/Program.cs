using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("SuperLista");

        List<string> lista = new List<string>();
        SuperLista<string> superLista = new SuperLista<string>();

        lista.Add("pierwszy");
        lista.Add("drugi");
        lista.Add("trzeci");
        Console.WriteLine(lista.ToString());

        superLista.Add("pierwszy");
        superLista.Add("drugi");
        superLista.Add("trzeci");
        Console.WriteLine(superLista.ToString());
    }

    class SuperLista<T> : List<T>
    {
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Enumerator e = this.GetEnumerator();
            int i = 0;
            while (e.MoveNext())
            {
                sb.AppendLine($"[{i++}]: \"{e.Current.ToString()}\".");
            }
            return sb.ToString();
        }
    }


}
internal class Program
{
    private static void Main(string[] args)
    {
        Poczatek p = new Poczatek();
        Odbiorca sub = new Odbiorca(p);
        Odbiorca sub2 = new Odbiorca(p);
        p.Go();
        Console.ReadLine();
    }
    public interface IStart
    { event EventHandler Start; }

    public class Poczatek : IStart
    {
        event EventHandler StartEvent;
        event EventHandler IStart.Start
        {
            add
            { StartEvent += value; }
            remove
            { StartEvent -= value; }
        }
        public void Go()
        {
            EventHandler handler = StartEvent;
            if (handler != null)
            {
                handler(this, new EventArgs());
            }
            Console.WriteLine("Po starcie.");
        }
    }
    public class Odbiorca
    {
        public Odbiorca(Poczatek p)
        {
            IStart d = (IStart)p;
            d.Start += new EventHandler(d_Start);
        }

        void d_Start(object sender, EventArgs e)
        {
            Console.WriteLine("Odbiorca startuje.");
        }
    }

}
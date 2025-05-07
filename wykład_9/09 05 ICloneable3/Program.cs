using System.Text;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("ICloneable3");
        StringBuilder red = new StringBuilder("red ");
        KolorowyPunkt kolorowyPunkt1 = new KolorowyPunkt(1, 2, red);
        KolorowyPunkt kolorowyPunkt2 = (KolorowyPunkt)kolorowyPunkt1.Clone();
        KolorowyPunkt kolorowyPunkt3 = (KolorowyPunkt)kolorowyPunkt1.DeepClone();
        red[0] = 'b'; red[1] = 'l'; red[2] = 'u'; red[3] = 'e';

        Console.WriteLine($"{kolorowyPunkt1}");
        Console.WriteLine($"{kolorowyPunkt2}");
        Console.WriteLine($"{kolorowyPunkt3}");
    }

    class KolorowyPunkt : Punkt
    {
        public StringBuilder kolor;
        public KolorowyPunkt(int x, int y, StringBuilder kolor) : base(x, y)
        {
            // implementacja typowa - przypisanie argumentu,
            // tak jak to zwykle robimy, nie myśląc czy to obiekt czy referencja
            // to dobrze zadziała dla zmiennych typu wartość, a dla referencji nie
            this.kolor = kolor;
            // teraz naprawdę robi sie lokalną kopię obiektu, na który wskazuje referencja
            // tak trzeba robić z każdym polem będącym referencją
            //this.kolor = new StringBuilder(kolor.ToString()); 
        }
        public virtual KolorowyPunkt DeepClone()
        {
            KolorowyPunkt kolorowy = (KolorowyPunkt)this.MemberwiseClone();
            kolorowy.kolor = new StringBuilder(kolor.ToString()); // tu naprawdę robi się lokalną kopię

            return kolorowy;
        }
        public override string ToString()
        {
            return String.Format($"{base.ToString()}, kolor={kolor}");
        }
    }
    class Punkt : ICloneable
    {
        public int x, y;
        public Punkt(int x, int y)
        {
            this.x = x; this.y = y;
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return String.Format($"x={x}, y={y}");
        }
    }
}
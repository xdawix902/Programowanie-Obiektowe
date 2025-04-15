internal class Program
{
    private static void Main(string[] args)
    {
        Shape p = new Shape();
        Subscriber s = new Subscriber(p);
        p.ChangeShape();
    
        Console.ReadLine();
    }
    public interface IDrawingObject
    {
        event EventHandler ShapeChanged;
    }
    public class Shape : IDrawingObject
    {
        public event EventHandler ShapeChanged;
        public void ChangeShape()
        {
            OnShapeChanged(new EventArgs());
        }
        protected virtual void OnShapeChanged(EventArgs e)
        {
            if (ShapeChanged != null)
            {
                ShapeChanged(this, e);
            }
        }
    }
    public class Subscriber
    {
        public Subscriber(Shape shape)
        {
            IDrawingObject d = (IDrawingObject)shape;
            d.ShapeChanged += new EventHandler(d_OnChange);
        }

        void d_OnChange(object sender, EventArgs e)
        {
            Console.WriteLine("Subscriber otrzymal IDrawingObject event.");
        }
    }
}
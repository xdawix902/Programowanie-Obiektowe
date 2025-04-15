using System;

namespace Event02
{
    class MyEvent
    {
        public event EventHandler SomeEvent; // EventHandler 
        // teraz klasa MyEvent obsługuje wydarzenie
        public void OnSomeEvent()
        {
            if (SomeEvent != null)
                // Tu zachodzi zdarzenie
                SomeEvent(this, EventArgs.Empty);
        }
    }
    public class EventDemo
    {
        static void handler(object source, EventArgs arg)
        {
            // Obsługa zdarzenia
            Console.WriteLine("zdarzenie");
            Console.WriteLine("nadawca " + source);
        }
        public static void Main()
        {
            MyEvent evt = new MyEvent();
            // teraz zapiszemy się do tego wydarzenia przez +=
            evt.SomeEvent += new EventHandler(handler); 
            evt.OnSomeEvent();
        }
    }
}

using System;

namespace Event01
{
    delegate void MyEventHandler();
    class MyEvent
    {
        // od tej chwili SomeEvent jest zdarzeniem
        public event MyEventHandler SomeEvent;
        public void OnSomeEvent()
        {   // co robimy gdy zdarzenie zaszło
            if (SomeEvent != null) 
                SomeEvent();
        }
    }
    public class EventDemo
    {
        static void handler()
        {   // obsługa zdarzenia
            Console.WriteLine("Zaszło zdarzenie!");
        }
        public static void Main()
        {
            MyEvent evt = new MyEvent();
            evt.SomeEvent += new MyEventHandler(handler);
            evt.OnSomeEvent();
            //evt.SomeEvent(); 
        }
    }
}

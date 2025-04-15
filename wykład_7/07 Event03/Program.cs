using System;

namespace Event03
{
    internal class Program
    {
        public class MyEventSubscriber
        {
            static void Main(string[] args)
            {
                MyEventPublisher EventPublisher = new MyEventPublisher();
                MyEventArgs MyArgs = new MyEventArgs();
                MyArgs.MyString = "Witajcie";
                EventPublisher.MyEvent += new MyDelegateEventHandler(MyHandler);
                EventPublisher.DoSomething(MyArgs);
            }
            static int MyHandler(MyEventArgs e)
            {
                Console.WriteLine(e.MyString);
                return 0;
            }
        }
    }

    public delegate int MyDelegateEventHandler(MyEventArgs e);

    public class MyEventArgs : EventArgs
    {
        public int MyInt;
        public long MyLong;
        public string MyString;
    }

    public class MyEventPublisher
    {
        public event MyDelegateEventHandler MyEvent;
        public int DoSomething(MyEventArgs e)
        {
            MyEvent(e);
            return 0;
        }
    }

}

using System.Reflection;
using System.Security.AccessControl;

namespace TheType
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            TheType.MyClass aClass = new TheType.MyClass();

            Type t = aClass.GetType();
            MethodInfo[] mi = t.GetMethods();
            foreach (MethodInfo m in mi)
                Console.WriteLine("Method: {0}\n", m.Name);

            Console.WriteLine("Full name is: {0}", t.FullName);
            Console.WriteLine("Base is: {0}", t.BaseType);
            Console.WriteLine("Is it abstract? {0}", t.IsAbstract);
            Console.WriteLine("Is it a COM object? {0}", t.IsCOMObject);
            Console.WriteLine("Is it sealed? {0}", t.IsSealed);
            Console.WriteLine("Is it a class? {0}", t.IsClass);

            Type tt = Type.GetType("System.Collections.Generic.List`1[System.Int32]");
            Console.WriteLine("Is it a generic class? {0}", tt.IsGenericType);
        }
    }
    public interface IFaceOne { void MethodA(); }
    public interface IFaceTwo { void MethodB(); }
    public class MyClass : IFaceOne, IFaceTwo
    {
        public int myIntField;
        public string myStringField;
        private double myDoubleField = 0;

        public double getMyDouble() { return myDoubleField; }
        public void myMethod(int p1, string p2) { }
        public int MyProp
        {
            get { return myIntField; }
            set { myIntField = value; }
        }
        public void MethodA() { }
        public void MethodB() { }
    }
}
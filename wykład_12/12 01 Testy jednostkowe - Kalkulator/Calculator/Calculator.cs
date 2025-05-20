using System;

namespace Calculator
{
    public class Calculator
    {
        public int Add(int a, int b)
        {
            long c = (long)a + b;
            return c > int.MaxValue ? int.MaxValue : (int)c;
        }

        public float Divide(int a, int b)
        {
            if (b == 0) throw new DivideByZeroException();
            return (float)a / b; 
        }
    }
}

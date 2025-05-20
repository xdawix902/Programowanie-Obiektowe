using System;
using NUnit.Framework;

namespace Calculator.Tests
{
    [TestFixture]
    public class CalculatorTests
    {
        public Calculator calc;
        
        [SetUp]
        public void SetUp()
        {
            calc = new Calculator();
        }
        
        [Test]
        public void AddTest_AddsTwoPositiveNumbers()
        {
            int sum = calc.Add(2, 2);
            Assert.AreEqual(4, sum);
        }

        [Test]
        public void AddTest_AddsTwoNegativeNumbers()
        {
            int sum = calc.Add(-2, -2);
            Assert.AreEqual(-4, sum);
        }

        [Test]
        public void DivideTest_DivisionByZero_ThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() => calc.Divide(2, 0));
        }

        [Test]
        public void AddTest_CheckOverflow()
        {
            int sum = calc.Add(int.MaxValue, int.MaxValue);
            Assert.AreEqual(int.MaxValue, sum);
        }

        [TearDown]
        public void TearDown()
        {
            calc = null;
        }
    }
}

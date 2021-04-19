using System;
using NUnit.Framework;

namespace NUnitDOJO
{
    [TestFixture]
    public class Tests4SetupExample
    {
        private int amount;
        [SetUp]
        public void Setup()
        {
            //Runs before each test
            amount = 10;
        }

        [Test]
        public void SomeTest()
        {
            // use amount
            Console.WriteLine(amount);
        }

        [Test]
        public void SomeTest2()
        {
            // use amount still 10
            Console.WriteLine(amount);
        }

        [TearDown]
        public void TearDown()
        {
            // Runs after each test
            // Only useful if you have an object that you need to dispose manually after each test
        }
    }
}
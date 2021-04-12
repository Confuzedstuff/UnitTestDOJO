using System;
using NUnit.Framework;

namespace TestProject
{
    [TestFixture]
    public class NUnitExample
    {
        [SetUp]
        public void Setup()
        {
            
        }
        
        [Test]
        public void Two_Greater_Than_One()
        {
            Assert.True(2 > 1);
        }
        
        [Test]
        public void Asset_Exception()
        {
            Assert.Throws<Exception>(() =>
            {
                throw new Exception("Help");
            });
        }
        
        [TearDown]
        public void TearDown()
        {
            
        }
    }
    
    [TestFixture]
    public class TestCases
    {
        [TestCase(0,1)]
        [TestCase(-555,-100)]
        public void Smaller_Number_Less_Than_Larger_Number(int smaller, int larger)
        {
            Assert.True(smaller < larger);
        }
    }
}
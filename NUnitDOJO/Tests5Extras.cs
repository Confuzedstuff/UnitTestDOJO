using System;
using System.Threading;
using NUnit.Framework;

namespace NUnitDOJO
{
    /// <summary>
    /// Check out https://docs.nunit.org/articles/nunit/writing-tests/attributes.html
    /// </summary>
    [TestFixture]
    public class Tests5Extras
    {
        [Test]
        [Repeat(3)]
        public void Test_Repeat()
        {
            // Do something that modifies state that persists outside of the test
            Assert.IsTrue(true);
        }


        [Test]
        [MaxTime(10000)]
        public void Test_Max_Time()
        {
            Thread.Sleep(5000); // Slow code under test
            Assert.IsTrue(true);
        }
        
        
        [Test]
        [Ignore("This code was ignored for a really good reason and I promise to fix it as soon as possible")]
        public void Test_To_Ignore()
        {
            throw new Exception("Ticket completed within time and budget constraints");
            Assert.IsTrue(true);
        }
    }
}
using System;
 using AutoMoq;
using Moq;
using NUnit.Framework;
using TestProject.ExampleTypes;

namespace TestProject
{
    [TestFixture]
    public class MoqExample
    {
        // Moq https://github.com/Moq/moq4/wiki/Quickstart
        private AutoMoqer autoMoqer; // https://github.com/darrencauthon/AutoMoq
        
        [SetUp]
        public void Setup()
        {
            autoMoqer = new AutoMoqer();
        }
        
        [Test]
        public void MockExample()
        {
            var someServiceMock = autoMoqer.Resolve<SomeService>();
            var someDependencyServiceMock = autoMoqer.GetMock<ISomeDependencyService>();

            someServiceMock.SomeMethod(It.IsAny<int>());
            
            // sometimes 
            someDependencyServiceMock.Verify(x=>x.AnotherMethod(It.IsAny<int>()), Times.Once);
            
        }
        
        [TearDown]
        public void TearDown()
        {
            
        }
    }

    
}
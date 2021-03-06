using System;
using AutoMoq;
// using AutoMoq;
using Domain;
using Moq;
using NUnit.Framework;
using Services;

namespace TestProject
{
    [TestFixture]
    public class RocketStartTests
    {
         private AutoMoqer autoMoqer;

        [SetUp]
        public void Setup()
        {
             autoMoqer = new AutoMoqer();
        }

        [Test]
        public void Assert_EngineValves_Are_Open()
        {
            var rocket = RocketStub();
            var engineMock = autoMoqer.GetMock<Engine>();
            rocket.Engine = engineMock.Object;
            var fueltank1 = new FuelTank(FuelType.Oxygen, 5);
            var fueltank2 = new FuelTank(FuelType.Methane, 5);
            
            rocket.FuelTanks.Add(fueltank1);
            rocket.FuelTanks.Add(fueltank2);
            
            rocket.StartEngine();
            
            engineMock.Verify(x=>x.OpenFuelValves(), Times.Once);
            
           // engineMock.Verify(x=>x.IgniteEngine(It.IsAny<FuelTank[]>()), Times.Once);
        }

        private Rocket RocketStub()
        {
            var rocket = new Rocket();
            return rocket;
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
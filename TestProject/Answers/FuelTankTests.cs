using System;
using AutoMoq;
// using AutoMoq;
using Domain;
using Domain.Exceptions.Logic;
using Domain.Exceptions.Rocket;
using Moq;
using NUnit.Framework;
using Services;

namespace TestProject
{
    [TestFixture]
    public class FuelTankTestsAnswers
    {
        private AutoMoqer autoMoqer;

        [SetUp]
        public void Setup()
        {
            autoMoqer = new AutoMoqer();
        }

        [Test]
        public void Assert_Refueler_Does_Not_Overfill()
        {
            var refueler = autoMoqer.Create<RefuelerService>();
            var fuelTank = new FuelTank(FuelType.Oxygen, 15);
            Assert.Throws<PreventOverfillException>(() => refueler.AddFuel(fuelTank, FuelType.Oxygen, 20));
        }

        [Test]
        public void Assert_Refueler_Does_Not_Mix_Fuel_Types()
        {
            var refueler = autoMoqer.Create<RefuelerService>();
            var fuelTank = new FuelTank(FuelType.Oxygen, 15);
            Assert.Throws<SameFuelException>(() => refueler.AddFuel(fuelTank, FuelType.Methane, 5));
        }

        [Test]
        public void Fuel_Tank_Ruptures_Above_Max_Amount()
        {
            var fuelTankService = autoMoqer.Create<FuelTankAssemblyService>();
            var fuelTank = fuelTankService.CreateFuelTank(FuelType.Oxygen, 100);
            Assert.Throws<FuelTankRuptured>(() => fuelTank.Fill(FuelType.Oxygen, 150));
        }

        [Test]
        public void Create_Fuel_Tank()
        {
            var fuelTankAssemblyServiceMock =
                autoMoqer.GetMock<IFuelTankAssemblyService>();

            fuelTankAssemblyServiceMock
                .Setup(x => x.CreateFuelTank(It.IsAny<FuelType>(), It.IsAny<int>()))
                .Returns(new FuelTank(FuelType.Methane, 15));

            var assemblyServiceMock = autoMoqer.Resolve<RocketAssemblyService>();

            var fuelTank = assemblyServiceMock.CreateFuelTank(FuelType.Oxygen, 1234);


            Assert.True(fuelTank.FuelType == FuelType.Methane);
        }

        [TearDown]
        public void TearDown()
        {
        }
    }
}
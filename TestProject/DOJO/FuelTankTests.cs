using System;
using AutoMoq;
// using AutoMoq;
using Domain;
using Domain.Exceptions.Logic;
using Moq;
using NUnit.Framework;
using Services;

namespace TestProject
{
    [TestFixture]
    public class FuelTankTests
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
            //Fuel tanks explode
        }

        [Test]
        public void Assert_Refueler_Does_Not_Mix_Fuel_Types()
        {
            //Fuel tanks explode
        }

        [Test]
        public void Fuel_Tank_Ruptures_Above_Max_Amount()
        {
            // Update `FuelTankRupturesAboveMaxAmount` to test values for both `Oxygen` and `Methane`
            
            var fuelTankService = autoMoqer.Create<FuelTankAssemblyService>();
            var fuelTank = fuelTankService.CreateFuelTank(FuelType.Oxygen, 100);
            Assert.Throws<Exception>(() => fuelTank.Fill(FuelType.Oxygen, 150));
        }

        [Test]
        public void Create_Fuel_Tank()
        {
            // Mock out IFuelTankAssemblyService.CreateFuelTank 
            
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
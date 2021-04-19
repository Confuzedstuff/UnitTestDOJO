using System;
using Domain;
using NUnit.Framework;

namespace NUnitDOJO
{
    [TestFixture]
    public class Tests1Introduction
    {
        [Test]
        public void Given_NewFuelTank_Then_FuelTankIsCreatedWithSpecifiedMaxVolume()
        {
            var tank = new FuelTank(FuelType.Oxygen, 10);

            Assert.AreEqual(10, tank.MaxVolume);
        }

        [Test]
        public void Given_NewFuelTank_Then_FuelTankIsCreatedWithSpecifiedFuelType()
        {
            var tank = new FuelTank(FuelType.Methane, 10);

            // TODO assert that tank.FuelType == FuelType.Methane
            
            Assert.Fail("Remove this line");
        }

        [Test]
        public void Given_NewFuelTank_Then_FuelTankShouldBeEmpty()
        {
            var tank = new FuelTank(FuelType.Oxygen, 5);
            
            // TODO assert that tank.CurrentFuelVolume == 0
            
            Assert.Fail("Remove this line");
        }
    }
}
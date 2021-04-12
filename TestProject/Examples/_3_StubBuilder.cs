using System;
using Domain;
using NUnit.Framework;

namespace TestProject
{
    /// Stubs builders are just a different way of newing up an object 
    [TestFixture]
    public class StubBuilderExample
    {
        [Test]
        public void Test1()
        {
            var fuelTank = new FuelTankStubBuilder()
                           .WithFuelType(FuelType.Oxygen)
                           .WithMaxVolume(100)
                           .Build();

            Assert.True(true);
        }
    }

    class FuelTankStubBuilder
    {
        private FuelType fuelTankType;
        private int maxVolume;

        public FuelTankStubBuilder WithFuelType(FuelType fuelTankType)
        {
            this.fuelTankType = fuelTankType;
            return this;
        }

        public FuelTankStubBuilder WithMaxVolume(int maxVolume)
        {
            this.maxVolume = maxVolume;
            return this;
        }

        public FuelTank Build()
        {
            return new FuelTank(fuelTankType, maxVolume);
        }
    }
}
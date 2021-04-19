using Domain;
using Domain.Exceptions.Rocket;
using NUnit.Framework;

namespace NUnitDOJO
{
    [TestFixture]
    public class Tests4Setup
    {
        private FuelTank tank;
        [SetUp]
        public void Setup()
        {
            tank = new FuelTank(FuelType.Oxygen, 10);
        }

        [Test]
        public void Given_NewFuelTank_When_ExessiveAmountOfFuelIsAddedToFuelTank_Then_FuelTankShouldRuptureOverfilled()
        {
            Assert.Throws<FuelTankRuptured>(() =>
            {
                tank.AddFuel(FuelType.Oxygen, 25);
            });
        }
        
        
        [Test]
        public void Given_NewFuelTank_When_ADifferentFuelTypeIsAddedToFuelTank_Then_FuelTankShouldExplode()
        {
            // TODO Since the fuel tank in this test already contains Oxygen try to add Methane to make it explode
            
            Assert.Fail(); // TODO remove this line
        }
    }
}
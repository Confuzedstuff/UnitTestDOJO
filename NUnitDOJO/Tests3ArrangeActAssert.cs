using Domain;
using NUnit.Framework;

namespace NUnitDOJO
{
    [TestFixture]
    public class Tests3ArrangeActAssert
    {
        //Arrange Act Assert
        [Test]
        public void Given_NewFuelTank_When_FuelIsAddedToEmptyTank_Then_CurrentVolumeEqualsAmountAdded_AAA_Example()
        {
            // Arrange
            var tank = new FuelTank(FuelType.Oxygen, 5);

            // Act
            tank.AddFuel(FuelType.Oxygen, 1);

            // Assert
            Assert.AreEqual(1, tank.CurrentFuelVolume);
        }


        [Test]
        public void Given_NewFuelTankWithFuel_When_RemovingAllFuel_Then_TheTankIsEmpty()
        {
            // Arrange
            var tank = new FuelTank(FuelType.Oxygen, 5);
            var amountOfFuel = 2;
            tank.AddFuel(FuelType.Oxygen, amountOfFuel);
            
            // Act
            // TODO Remove the added fuel
            
            
            // Assert
            // TODO Assert that volume removed is is correct -> tank.CurrentFuelVolume
        }
        
        [Test]
        public void Given_NewFuelTankWithFuel_When_RemovingMoreFuelThanIsCurrentlyInTank_Then_TheTankShouldNotRemoveMoreFuelThanExistsInTheTank()
        {
            // Arrange
            var tank = new FuelTank(FuelType.Oxygen, 5);
            var amountOfFuel = 2;
            tank.AddFuel(FuelType.Oxygen, amountOfFuel);
            
            // Act
            // TODO Try to remove more than was added the fuel i.e. remove > 2 fuel and must return no more than 2 fuel
            
            
            // Assert
            // TODO Assert that tank is empty -> tank.CurrentFuelVolume not negative
        }
    }
}
using Domain;
using NUnit.Framework;

namespace NUnitDOJO
{
    [TestFixture]
    public class Tests2TestCases
    {
        [TestCase("hello", false)]
        [TestCase("test", false)]
        [TestCase("", true)]
        public void Test4_Example(string text, bool expected)
        {
            var actual = string.IsNullOrEmpty(text);

            Assert.AreEqual(expected, actual);
        }
        
        // TODO add test cases for each type of fuel
        [Test]
        public void Given_NewFuelTank_When_FuelIsAddedToEmptyTank_Then_CurrentVolumeEqualsAmountAdded()
        {
            var tank = new FuelTank(FuelType.Oxygen, 5);

            tank.AddFuel(FuelType.Oxygen, 1);

            Assert.AreEqual(1, tank.CurrentFuelVolume);
        }
    }
}
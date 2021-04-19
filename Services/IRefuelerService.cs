using System;
using Domain;
using Domain.Exceptions.Logic;

namespace Services
{
    public interface IRefuelerService
    {
        void AddFuel(FuelTank fuelTank, FuelType fuelType, int amountToAdd);
    }

    public class RefuelerService : IRefuelerService
    {
        public void AddFuel(FuelTank fuelTank, FuelType fuelType, int amountToAdd)
        {
            AssertEnsureFuelTypeIsTheSame(fuelTank, fuelType);
            AssertIfFuelTankWillRupture(fuelTank, amountToAdd);
            fuelTank.AddFuel(fuelType, amountToAdd);
        }

        private void AssertIfFuelTankWillRupture(FuelTank fuelTank, int amountToAdd)
        {
            var predictedTotal = fuelTank.CurrentFuelVolume + amountToAdd;
            if (predictedTotal > fuelTank.MaxVolume)
            {
                throw new PreventOverfillException(fuelTank);
            }
        }

        private void AssertEnsureFuelTypeIsTheSame(FuelTank fuelTank, FuelType fuelType)
        {
            if (fuelTank.FuelType != fuelType)
            {
                throw new SameFuelException(fuelTank, fuelType);
            }
        }
    }
}
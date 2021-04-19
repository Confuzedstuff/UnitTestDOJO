using System;
using Domain.Exceptions.Rocket;

namespace Domain
{
    public class FuelTank
    {
        public FuelTank(FuelType fuelType, int maxVolume)
        {
            FuelType = fuelType;
            MaxVolume = maxVolume;
        }

        public FuelType FuelType { get; }
        public int MaxVolume { get; }
        public int CurrentFuelVolume { get; private set; }

        public void AddFuel(FuelType fuelType, int amount)
        {
            CheckDoNotMixDifferentFuels(fuelType);
            this.CurrentFuelVolume += amount;
            CheckFuelTankRuptured();
        }

        private void CheckFuelTankRuptured()
        {
            if (this.CurrentFuelVolume > this.MaxVolume)
            {
                throw new FuelTankRuptured();
            }
        }

        private void CheckDoNotMixDifferentFuels(FuelType fuelType)
        {
            if (fuelType != this.FuelType)
            {
                throw new Exception("Explosion! Do not mix different fuels");
            }
        }

        public int RemoveFuel(int amountToRemove)
        {
            if (this.CurrentFuelVolume <= 0)
            {
                return 0;
            }

            if (amountToRemove <= this.CurrentFuelVolume)
            {
                this.CurrentFuelVolume -= amountToRemove;
                return amountToRemove;
            }

            var lastBitOfFuel = this.CurrentFuelVolume;
            this.CurrentFuelVolume = 0;
            return lastBitOfFuel;
        }

        public int RemoveAllFuel()
        {
            return this.RemoveFuel(this.CurrentFuelVolume);
        }

        public override string ToString() => $"Fueltank: {FuelType} {CurrentFuelVolume}L";
    }
}
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
        public int Amount { get; private set; }

        public void Fill(FuelType fuelType, int amount)
        {
            CheckDoNotMixFuelAndOxidizer(fuelType);
            this.Amount += amount;
            CheckFuelTankRuptured();
        }

        private void CheckFuelTankRuptured()
        {
            if (this.Amount > this.MaxVolume)
            {
                throw new FuelTankRuptured();
            }
        }

        private void CheckDoNotMixFuelAndOxidizer(FuelType fuelType)
        {
            if (fuelType != this.FuelType)
            {
                throw new Exception("Do not mix fuel with oxidizer");
            }
        }

        public int SupplyFuel(int amountToSupply)
        {
            if (this.Amount <= 0)
            {
                return 0;
            }

            if (amountToSupply <= this.Amount)
            {
                this.Amount -= amountToSupply;
                return amountToSupply;
            }

            var lastBitOfFuel = this.Amount;
            this.Amount = 0;
            return lastBitOfFuel;
        }

        public override string ToString()
        {
            return $"Fueltank: {FuelType} {Amount}L";
        }
    }
}
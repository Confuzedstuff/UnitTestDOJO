using Domain;

namespace Services
{
    public class FuelTankAssemblyService : IFuelTankAssemblyService
    {
        public FuelTank CreateFuelTank(FuelType fuelType, int maxVolume)
        {
            return new FuelTank(fuelType, maxVolume);
        }
    }
}
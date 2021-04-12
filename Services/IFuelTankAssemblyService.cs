using Domain;

namespace Services
{
    public interface IFuelTankAssemblyService
    {
        FuelTank CreateFuelTank(FuelType fuelType, int maxVolume);
    }
}
using Domain;

namespace Services
{
    public interface IRocketAssemblyService
    {
        Rocket CreateRocket();
        void AddFuelTank(Rocket rocket, FuelTank fuelTank);
        void AddEngine(Rocket rocket, Engine engine);

        Engine CreateEngine();
        FuelTank CreateFuelTank(FuelType methane, int maxVolume);
    }
}
using Domain;

namespace Services
{
    public class RocketAssemblyService : IRocketAssemblyService
    {
        private readonly IEngineAssemblyService engineAssemblyService;
        private readonly IFuelTankAssemblyService fuelTankAssemblyService;

        public RocketAssemblyService(IEngineAssemblyService engineAssemblyService,
                                     IFuelTankAssemblyService fuelTankAssemblyService)
        {
            this.engineAssemblyService = engineAssemblyService;
            this.fuelTankAssemblyService = fuelTankAssemblyService;
        }

        public Rocket CreateRocket() => new Rocket();

        public void AddFuelTank(Rocket rocket, FuelTank fuelTank)
        {
            rocket.FuelTanks.Add(fuelTank);
        }

        public void AddEngine(Rocket rocket, Engine engine)
        {
            rocket.Engine = engine;
        }

        public Engine CreateEngine()
        {
            return this.engineAssemblyService.CreateEngine();
        }

        public FuelTank CreateFuelTank(FuelType fuelType, int maxVolume)
        {
            return this.fuelTankAssemblyService.CreateFuelTank(fuelType, maxVolume);
        }
    }
}
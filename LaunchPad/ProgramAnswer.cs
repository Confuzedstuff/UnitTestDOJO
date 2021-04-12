using System;
using Domain;
using Domain.Exceptions;
using Domain.Exceptions.Logic;
using Domain.Exceptions.Rocket;
using Microsoft.Extensions.DependencyInjection;
using Services;

namespace LaunchPad
{
    class ProgramAnswer
    {
        private readonly IRocketAssemblyService rocketAssemblyService;
        private readonly IRefuelerService refuelerService;

        public ProgramAnswer(IRocketAssemblyService rocketAssemblyService,
                             IRefuelerService refuelerService)
        {
            this.rocketAssemblyService = rocketAssemblyService;
            this.refuelerService = refuelerService;
        }

        private void Run()
        {
            var rocket = this.rocketAssemblyService.CreateRocket();
            var engine = this.rocketAssemblyService.CreateEngine();
            var methaneTank = this.rocketAssemblyService.CreateFuelTank(FuelType.Methane, maxVolume:10);
            var oxygenTank = this.rocketAssemblyService.CreateFuelTank(FuelType.Oxygen, maxVolume:10);

            this.rocketAssemblyService.AddEngine(rocket, engine);// TODO remove
            this.rocketAssemblyService.AddFuelTank(rocket, methaneTank);
            this.rocketAssemblyService.AddFuelTank(rocket, oxygenTank);

            refuelerService.AddFuel(methaneTank,FuelType.Methane, 10); // TODO overfill
            refuelerService.AddFuel(oxygenTank, FuelType.Oxygen, 10);

            try
            {
                const int targetAltitude = 10;// 10km is target altitude for this test, do not change
                rocket.Launch(targetAltitude);
            }
            catch (LogicException e)
            {
                Console.WriteLine("Something went wrong, launch aborted, the rocket is safe");
                Console.WriteLine(e);
                throw;
            }
            catch (Exception e)
            {
                Console.WriteLine("Something went wrong, the rocket is destroyed");
                Console.WriteLine(e);
                throw;
            }
            

            Console.WriteLine("Success! Rocket launched successfully!");
        }

        #region Startup

        // static void Main(string[] args)
        // {
        //     var serviceProvider = ConfigureServices();
        //     serviceProvider.GetService<Program>().Run();
        // }

        private static ServiceProvider ConfigureServices()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddSingleton<Program>();
            serviceCollection.AddSingleton<IRocketAssemblyService, RocketAssemblyService>();
            serviceCollection.AddSingleton<IEngineAssemblyService, EngineAssemblyService>();
            serviceCollection.AddSingleton<IFuelTankAssemblyService, FuelTankAssemblyService>();
            serviceCollection.AddSingleton<IRefuelerService, RefuelerService>();
            return serviceCollection.BuildServiceProvider();
        }

        #endregion
    }


}
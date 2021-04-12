using System;
using System.Collections.Generic;
using System.Threading;
using Domain.Exceptions.Rocket;

namespace Domain
{
    public class Rocket
    {
        public decimal CurrentAltitude { get; set; }
        public Engine Engine { get; set; }
        public List<FuelTank> FuelTanks { get; } = new List<FuelTank>();

        public void Launch(decimal targetAltitude)
        {
            StartEngine();
            FlyToAltitude(targetAltitude);
        }

        private void FlyToAltitude(decimal targetAltitude)
        {
            while (this.CurrentAltitude < targetAltitude)
            {
                this.Engine.RunEngine(this, this.FuelTanks, 1);
                Thread.Sleep(100);
                Console.WriteLine($"Current altitude {CurrentAltitude}km, Remaining fuel {FuelTanks[0]}, {FuelTanks[1]}");
            }
        }

        public void StartEngine()
        {
            if (this.Engine == null)
            {
                throw new NoEngineInstalled();
            }

            this.Engine.IgniteEngine(this.FuelTanks);
        }
    }
}
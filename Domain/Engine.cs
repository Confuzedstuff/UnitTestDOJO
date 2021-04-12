using System;
using System.Collections.Generic;
using System.Linq;
using Domain.Exceptions.Rocket;

namespace Domain
{
    public class Engine
    {
        private bool fuelValveOpen = false;
        private bool isEngineStarted = false;

        public void OpenFuelValves()
        {
            this.fuelValveOpen = true;
        }

        public void IgniteEngine(IReadOnlyList<FuelTank> fuelTanks)
        {
            CheckFuelValveOpen();
            CheckFuelTankCount(fuelTanks);
            CheckDifferentFuels(fuelTanks);

            this.isEngineStarted = true;
        }

        private void CheckFuelValveOpen()
        {
            if (!this.fuelValveOpen)
            {
                throw new FuelValvesNotOpen();
            }
        }

        public void RunEngine(Rocket rocket, IReadOnlyList<FuelTank> fuelTanks, int enginePower)
        {
            CheckEngineStarted();

            var fuelMix = fuelTanks.Select(x => x.SupplyFuel(enginePower)).ToList();
            CheckFuelRatio(fuelMix);
            CheckEnoughFuel(enginePower, fuelMix);
            rocket.CurrentAltitude += enginePower;
        }

        private static void CheckEnoughFuel(int enginePower, List<int> fuelMix)
        {
            if (fuelMix.Sum(x => x) != (enginePower * 2))
            {
                throw new RocketException("Insufficient fuel");
            }
        }

        private void CheckEngineStarted()
        {
            if (!this.isEngineStarted)
            {
                throw new RocketException("Engine not started");
            }
        }

        private void CheckFuelRatio(IReadOnlyList<int> fuelMix)
        {
            var part1 = fuelMix[0];
            var part2 = fuelMix[1];
            if (part1 != part2)
            {
                throw new RocketException("Engines damaged fuel ratio not 1:1");
            }
        }

        private static void CheckFuelTankCount(IReadOnlyList<FuelTank> fuelTanks)
        {
            if (fuelTanks.Count != 2)
            {
                throw new RocketException("Incorrect number of fuel tanks connected", false);
            }
        }

        private static void CheckDifferentFuels(IReadOnlyList<FuelTank> fuelTanks)
        {
            var tank1 = fuelTanks[0];
            var tank2 = fuelTanks[1];
            if (tank1.FuelType != tank2.FuelType) return;
            switch (tank1.FuelType)
            {
                case FuelType.Oxygen:
                    throw new RocketException("Engine damaged, burning oxygen rich fuel");
                case FuelType.Methane:
                    throw new RocketException("Engine damaged, burning methane rich fuel");
            }
        }
    }
}
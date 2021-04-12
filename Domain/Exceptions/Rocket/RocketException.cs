using System;

namespace Domain.Exceptions.Rocket
{
    public class RocketException : Exception
    {
        public readonly bool IsFatal;

        public RocketException(string message, bool isFatal = true) : base(message)
        {
            this.IsFatal = isFatal;
        }

        
    }
    
    public class FuelValvesNotOpen : RocketException
    {
        public FuelValvesNotOpen() : base("Engine misfire, fuel valves not open")
        {
                
        }
    }

    public class NoEngineInstalled : RocketException
    {
        public NoEngineInstalled():base("No engine installed")
        {
            
        }
    }

    public class FuelTankRuptured : RocketException
    {
        public FuelTankRuptured() : base("Fuel tank ruptured")
        {
            
        }
    }
}
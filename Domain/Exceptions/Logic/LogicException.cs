using System;

namespace Domain.Exceptions.Logic
{
    public class LogicException : Exception
    {
        public LogicException(string message) : base(message)
        {
            
        }
    }
    public class PreventOverfillException : LogicException
    {
        public PreventOverfillException(FuelTank fuelTank):base($"Refueling will exceed maximum fuel tank volume, {fuelTank}") 
        {
        }
    }
    
    public class SameFuelException : LogicException
    {
        public SameFuelException(FuelTank fuelTank, FuelType fuelType):base($"FuelType is not the same {fuelTank} {fuelType}") 
        {
        }
    }
}
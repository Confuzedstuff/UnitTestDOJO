namespace Domain.Exceptions.Rocket
{
    public class FuelValvesNotOpen : RocketException
    {
        public FuelValvesNotOpen() : base("Engine misfire, fuel valves not open")
        {
                
        }
    }
}
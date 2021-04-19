namespace Domain.Exceptions.Rocket
{
    public class NoEngineInstalled : RocketException
    {
        public NoEngineInstalled():base("No engine installed")
        {
            
        }
    }
}
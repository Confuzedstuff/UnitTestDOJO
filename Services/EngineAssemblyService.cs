using Domain;

namespace Services
{
    public class EngineAssemblyService : IEngineAssemblyService
    {
        public Engine CreateEngine()
        {
            return new Engine();
        }
    }
}
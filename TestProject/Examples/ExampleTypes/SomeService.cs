namespace TestProject.ExampleTypes
{
    public class SomeService:ISomeService
    {
        private readonly ISomeDependencyService someDependencyService;
        private readonly ISomeOtherDependencyService someOtherDependencyService;

        public SomeService(ISomeDependencyService someDependencyService, 
                           ISomeOtherDependencyService someOtherDependencyService)
        {
            this.someDependencyService = someDependencyService;
            this.someOtherDependencyService = someOtherDependencyService;
        }

        public void SomeMethod(int amount)
        {
            someDependencyService.AnotherMethod(amount);
            someOtherDependencyService.AnotherMethod();
        }
    }
}
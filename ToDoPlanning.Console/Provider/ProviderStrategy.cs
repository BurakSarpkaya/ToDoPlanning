namespace ToDoPlanning.Console.Provider
{
    public class ProviderStrategy
    {
        private IProviderService _currentProviderService;

        public ProviderStrategy(IProviderService currentProviderService)
        {
            _currentProviderService = currentProviderService;
        }

        public void ExecuteStrategy()
        {
            _currentProviderService?.InsertProjectData().Wait();
        }
    }
}

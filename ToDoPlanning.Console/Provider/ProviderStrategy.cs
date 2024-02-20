namespace ToDoPlanning.Console.Provider
{
    public class ProviderStrategy
    {
        private IProviderService _currentProviderService;

        public ProviderStrategy(IProviderService currentProviderService)
        {
            _currentProviderService = currentProviderService;
        }

        public async Task ExecuteStrategy()
        {
           await _currentProviderService.InsertProjectData();
        }
    }
}

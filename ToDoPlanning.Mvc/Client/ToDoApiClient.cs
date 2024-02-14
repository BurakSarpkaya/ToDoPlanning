using ToDoPlanning.Mvc.Configuration;
using ToDoPlanning.Mvc.Models;

namespace ToDoPlanning.Mvc.Client
{
    public class ToDoApiClient : IToDoApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly ToDoPlanningApiSettings _toDoPlanningApiSettings;
        public ToDoApiClient(HttpClient httpClient, ToDoPlanningApiSettings toDoPlanningApiSettings)
        {
            _httpClient = httpClient;
            _toDoPlanningApiSettings = toDoPlanningApiSettings;
        }
        public async Task<List<DeveloperViewModel>> GetDevelopersWeeklyPlans()
        {
            var response = await _httpClient.GetAsync(_toDoPlanningApiSettings.ToDoPlanningApiUrl);
            response.EnsureSuccessStatusCode();

            var developers = await response.Content.ReadFromJsonAsync<List<DeveloperViewModel>>();

            return developers;
        }
    }
}

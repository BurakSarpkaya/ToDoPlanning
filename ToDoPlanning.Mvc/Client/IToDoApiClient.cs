using ToDoPlanning.Mvc.Models;

namespace ToDoPlanning.Mvc.Client
{
    public interface IToDoApiClient
    {
        public Task<List<DeveloperViewModel>> GetDevelopersWeeklyPlans();
    }
}

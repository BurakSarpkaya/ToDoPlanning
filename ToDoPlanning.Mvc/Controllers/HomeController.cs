using Microsoft.AspNetCore.Mvc;
using ToDoPlanning.Mvc.Client;

public class HomeController : Controller
{
    private readonly IToDoApiClient _toDoApiClient;

    public HomeController(IToDoApiClient toDoApiClient)
    {
        _toDoApiClient = toDoApiClient;
    }

    public async Task<IActionResult> Index()
    {
        var response = await _toDoApiClient.GetDevelopersWeeklyPlans();

        return View(response);
    }
}

using ToDoPlanning.Api.CQRS.Queries.Dtos;

namespace ToDoPlanning.Api.CQRS.Queries.Response
{
    public class GetDeveloperPlanQueryResponse
    {
        public int TotalWeek { get; set; }
        public DeveloperDto Developer { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}

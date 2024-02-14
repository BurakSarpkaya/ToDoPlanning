namespace ToDoPlanning.Api.CQRS.Queries.Dtos
{
    public class WeeklyTaskDto
    {
        public int WeekNumber { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}

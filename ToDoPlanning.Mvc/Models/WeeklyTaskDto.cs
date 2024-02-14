namespace ToDoPlanning.Mvc.Models
{
    public class WeeklyTaskDto
    {
        public int WeekNumber { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}

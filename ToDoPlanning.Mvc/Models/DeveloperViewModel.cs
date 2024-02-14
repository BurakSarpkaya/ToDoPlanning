namespace ToDoPlanning.Mvc.Models
{
    public class DeveloperViewModel
    {
        public int TotalWeek { get; set; }
        public DeveloperDto Developer { get; set; }
        public List<TaskDto> Tasks { get; set; }
    }
}

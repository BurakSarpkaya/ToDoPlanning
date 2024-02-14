namespace ToDoPlanning.Console.Provider.Model
{
    public class DeveloperV2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Capacity { get; set; }
    }

    public class TaskV2
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }
        public int DeveloperId { get; set; }
    }

    public class ProjectDataV2
    {
        public List<DeveloperV2> Developers { get; set; }
        public List<TaskV2> Tasks { get; set; }
    }
}

namespace ToDoPlanning.Api.Models
{
    public class Tasks : BaseEntity
    {
        public string? Name { get; set; }
        public int Duration { get; set; }
        public int Level { get; set; }
        public string? AssignedDeveloper { get; set; }
        public int? DeveloperId { get; set; }
    }
}

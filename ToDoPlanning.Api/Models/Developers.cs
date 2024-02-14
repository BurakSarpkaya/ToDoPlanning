namespace ToDoPlanning.Api.Models
{
    public class Developers : BaseEntity
    {
        public string? Name { get; set; }
        public int Level { get; set; }
        public List<Tasks> Tasks { get; set; }
        public int? ProviderId { get; set; }
    }
}

namespace ToDoPlanning.Console.Models
{
    public class Developers : BaseEntity
    {
        public string Name { get; set; }
        public int Level { get; set; }
        public List<Tasks> Tasks { get; set; }

    }
}

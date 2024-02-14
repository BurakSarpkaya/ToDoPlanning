using Newtonsoft.Json;

namespace ToDoPlanning.Console.Provider.Model
{
    public class DeveloperV1
    {
        public string Name { get; set; }

        [JsonProperty("hourly_capacity")]
        public int HourlyCapacity { get; set; }
    }

    public class TaskV1
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Difficulty { get; set; }

        [JsonProperty("assigned_developer")]
        public string AssignedDeveloper { get; set; }
    }

    public class ProjectData
    {
        public List<DeveloperV1> Developers { get; set; }
        public List<TaskV1> Tasks { get; set; }
    }
}

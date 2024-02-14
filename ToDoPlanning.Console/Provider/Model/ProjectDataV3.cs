using System.Xml.Serialization;

namespace ToDoPlanning.Console.Provider.Model
{
    [XmlRoot("project")]
    public class ProjectDataV3
    {
        [XmlArray("developers")]
        [XmlArrayItem("developer")]
        public List<DeveloperV3> Developers { get; set; }

        [XmlArray("tasks")]
        [XmlArrayItem("task")]
        public List<TaskV3> Tasks { get; set; }
    }

    public class DeveloperV3
    {
        [XmlElement("dev_name")]
        public string Name { get; set; }

        [XmlElement("capacity_per_hour")]
        public int CapacityPerHour { get; set; }
    }

    public class TaskV3
    {
        [XmlElement("task_id")]
        public int Id { get; set; }

        [XmlElement("task_name")]
        public string Name { get; set; }

        [XmlElement("task_duration")]
        public int Duration { get; set; }

        [XmlElement("task_difficulty")]
        public int Difficulty { get; set; }

        [XmlElement("task_assigned_to")]
        public string AssignedTo { get; set; }
    }
}

﻿namespace ToDoPlanning.Api.CQRS.Queries.Dtos
{
    public class TaskDto
    {
        public string? Name { get; set; }
        public int Duration { get; set; }
        public int Level { get; set; }
    }
}

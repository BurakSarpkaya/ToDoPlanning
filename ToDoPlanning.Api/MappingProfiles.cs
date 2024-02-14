using AutoMapper;
using ToDoPlanning.Api.CQRS.Queries.Dtos;
using ToDoPlanning.Api.Models;

namespace ToDoPlanning.Api
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Tasks, TaskDto>();

            CreateMap<Developers, DeveloperDto>();
        }
    }
}

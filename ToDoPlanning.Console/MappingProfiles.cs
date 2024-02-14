using AutoMapper;
using ToDoPlanning.Console.Models;
using ToDoPlanning.Console.Provider.Model;

namespace ToDoPlanning.Console
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<DeveloperV1, Developers>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.HourlyCapacity));

            CreateMap<DeveloperV2, Developers>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Capacity));

            CreateMap<DeveloperV3, Developers>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
            .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.CapacityPerHour));

            CreateMap<TaskV1, Tasks>()
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Difficulty))
               .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<TaskV2, Tasks>()
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Difficulty))
               .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<TaskV3, Tasks>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ForMember(dest => dest.Level, opt => opt.MapFrom(src => src.Difficulty))
            .ForMember(dest => dest.AssignedDeveloper, opt => opt.MapFrom(src => src.AssignedTo));

        }
    }
}

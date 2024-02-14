using AutoMapper;
using MediatR;
using MongoDB.Bson;
using MongoDB.Driver;
using ToDoPlanning.Api.CQRS.Queries.Dtos;
using ToDoPlanning.Api.CQRS.Queries.Request;
using ToDoPlanning.Api.CQRS.Queries.Response;
using ToDoPlanning.Api.Models;

namespace ToDoPlanning.Api.CQRS.Handlers.QueryHandler
{
    public class GetDeveloperPlanQueryHandler : IRequestHandler<GetDeveloperPlanQueryRequest, List<GetDeveloperPlanQueryResponse>>
    {
        private readonly MongoDBContext _context;
        private readonly IMapper _mapper;

        public GetDeveloperPlanQueryHandler(MongoDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<GetDeveloperPlanQueryResponse>> Handle(GetDeveloperPlanQueryRequest request, CancellationToken cancellationToken)
        {
            List<GetDeveloperPlanQueryResponse> assignTasksGreedy = new List<GetDeveloperPlanQueryResponse>();

            var developerList = await _context.Developers.Find(new BsonDocument()).ToListAsync();
            var developers = _mapper.Map<List<DeveloperDto>>(developerList);

            var taskList = await _context.Tasks.Find(new BsonDocument()).ToListAsync();
            var tasks = _mapper.Map<List<TaskDto>>(taskList);

            var result = AssignTasksGreedy(developers, tasks);

            foreach (var entry in result)
            {
                var response = new GetDeveloperPlanQueryResponse
                {
                    Developer = entry.Key,
                    Tasks = entry.Value
                };

                // Calculate the total weeks for the developer's tasks
                int totalDuration = entry.Value.Sum(task => task.Duration);
                int weeksToComplete = CalculateWeeks(totalDuration, response.Developer.Level);
                response.TotalWeek = weeksToComplete;

                assignTasksGreedy.Add(response);
            }

            return assignTasksGreedy;
        }

        private Dictionary<DeveloperDto, List<TaskDto>> AssignTasksGreedy(List<DeveloperDto> developers, List<TaskDto> tasks)
        {
            var weeklyAssignments = new Dictionary<DeveloperDto, List<TaskDto>>();

            // Developer'ları saatlik kapasitelerine göre sırala (en fazla işi yapabilen ilk sırada olacak)
            developers.Sort((dev1, dev2) => dev2.Level.CompareTo(dev1.Level));

            foreach (var developer in developers)
            {
                weeklyAssignments.Add(developer, new List<TaskDto>());
            }

            // Görevleri zorluk derecesine göre sırala
            tasks.Sort((t1, t2) => t2.Level.CompareTo(t1.Level));

            while (tasks.Count > 0)
            {
                // Developer'ın saatlik kapasitesi kadar işi yapacak şekilde görevleri ata
                foreach (var developer in developers)
                {
                    var availableHours = developer.Level * 45;

                    var task = tasks.Find(t => t.Duration <= availableHours);
                    if (task != null)
                    {
                        weeklyAssignments[developer].Add(task);
                        tasks.Remove(task);
                        availableHours -= task.Duration;
                    }
                }
            }

            return weeklyAssignments;
        }

        private int CalculateWeeks(int totalDuration, int hourlyCapacity)
        {
            return (int)Math.Ceiling((double)totalDuration / (45 * hourlyCapacity));
        }
    }
}

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

            var result = AssignTasks(developers, tasks);

            foreach (var entry in result)
            {
                var response = new GetDeveloperPlanQueryResponse
                {
                    Developer = entry.Key,
                    WeeklyTasks = new List<WeeklyTaskDto>()
                };

                int totalDuration = entry.Value.Sum(task => task.Duration);
                int weeksToComplete = CalculateWeeks(totalDuration, response.Developer.Level);
                response.TotalWeek = weeksToComplete;

                for (int week = 1; week <= weeksToComplete; week++)
                {
                    var weeklyTasks = entry.Value
                        .Where(task => task.Week == week)
                        .ToList();

                    response.WeeklyTasks.Add(new WeeklyTaskDto
                    {
                        WeekNumber = week,
                        Tasks = weeklyTasks
                    });
                }

                assignTasksGreedy.Add(response);
            }

            return assignTasksGreedy;
        }

        private Dictionary<DeveloperDto, List<TaskDto>> AssignTasks(List<DeveloperDto> developers, List<TaskDto> tasks)
        {
            var weeklyAssignments = new Dictionary<DeveloperDto, List<TaskDto>>();

            developers.Sort((dev1, dev2) => dev2.Level.CompareTo(dev1.Level));

            foreach (var developer in developers)
            {
                weeklyAssignments.Add(developer, new List<TaskDto>());
            }

            tasks.Sort((t1, t2) => t2.Level.CompareTo(t1.Level));

            int weekCounter = 1;

            while (tasks.Count > 0)
            {
                bool taskAssigned = false;

                foreach (var developer in developers)
                {
                    var availableHours = developer.Level * 45;

                    var task = tasks.FirstOrDefault(t => t.Duration <= availableHours);

                    if (task != null)
                    {
                        task.Week = weekCounter; 
                        weeklyAssignments[developer].Add(task);
                        tasks.Remove(task);
                        taskAssigned = true;
                    }
                }

                if (!taskAssigned)
                {
                    weekCounter++;
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

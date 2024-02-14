using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using ToDoPlanning.Console.Models;
using ToDoPlanning.Console.Provider.Model;

namespace ToDoPlanning.Console.Provider
{
    public class ProviderServiceV2 : IProviderService
    {
        private readonly MongoDBContext _context;
        private readonly IMapper _mapper;
        private readonly HttpClient _client;

        public ProviderServiceV2(MongoDBContext context, IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
            _context = context;

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<MappingProfiles>();
            });


            _mapper = config.CreateMapper();
        }
        public async Task InsertProjectData()
        {
            _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            var url = "https://run.mocky.io/v3/dcefd558-2d11-4035-9e94-2d6ce27675e0?mocky-delay=5s";
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();

            ProjectDataV2 projectData = JsonConvert.DeserializeObject<ProjectDataV2>(resp);

            List<Developers> developers = _mapper.Map<List<Developers>>(projectData?.Developers);
            await _context.Developers.InsertManyAsync(developers);

            List<Tasks> tasks = _mapper.Map<List<Tasks>>(projectData?.Tasks);
            await _context.Tasks.InsertManyAsync(tasks);
        }
    }
}

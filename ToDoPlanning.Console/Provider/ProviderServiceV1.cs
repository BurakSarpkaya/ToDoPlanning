using AutoMapper;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using ToDoPlanning.Console.Models;
using ToDoPlanning.Console.Provider.Model;

namespace ToDoPlanning.Console.Provider
{
    public class ProviderServiceV1 : IProviderService
    {
        private readonly MongoDBContext _context;
        private readonly IMapper _mapper;
        private readonly HttpClient _client;

        public ProviderServiceV1(MongoDBContext context, IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient();
            _context = context;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MappingProfiles>();
            });


            _mapper = config.CreateMapper();
        }
        public async Task InsertProjectData()
        {
            _client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));

            var url = "https://run.mocky.io/v3/0f7a9194-a5d8-4050-91a6-ab087c8a196b";
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();

            ProjectData projectData = JsonConvert.DeserializeObject<ProjectData>(resp);

            List<Developers> developers = _mapper.Map<List<Developers>>(projectData?.Developers);
            await _context.Developers.InsertManyAsync(developers);

            List<Tasks> tasks = _mapper.Map<List<Tasks>>(projectData?.Tasks);
            await _context.Tasks.InsertManyAsync(tasks);

        }
    }
}

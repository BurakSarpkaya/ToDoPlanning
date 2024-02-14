using AutoMapper;
using System.Xml.Serialization;
using ToDoPlanning.Console.Models;
using ToDoPlanning.Console.Provider.Model;

namespace ToDoPlanning.Console.Provider
{
    public class ProviderServiceV3 : IProviderService
    {
        private readonly MongoDBContext _context;
        private readonly IMapper _mapper;
        private readonly HttpClient _client;

        public ProviderServiceV3(MongoDBContext context, IHttpClientFactory httpClientFactory)
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
            var url = "https://run.mocky.io/v3/a7775176-a4c6-4c54-be06-caa440df6985?mocky-delay=15s";
            HttpResponseMessage response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();
            var resp = await response.Content.ReadAsStringAsync();

            var serializer = new XmlSerializer(typeof(ProjectDataV3));
            using (TextReader reader = new StringReader(resp))
            {
                ProjectDataV3 projectData = (ProjectDataV3)serializer.Deserialize(reader);
                List<Developers> developers = _mapper.Map<List<Developers>>(projectData?.Developers);
                await _context.Developers.InsertManyAsync(developers);

                List<Tasks> tasks = _mapper.Map<List<Tasks>>(projectData?.Tasks);
                await _context.Tasks.InsertManyAsync(tasks);
            }
        }
    }
}


using Newtonsoft.Json;
using MovieStoreTISAI.Models.DTO;
using System.Text;

namespace MovieStoreTISAI.BackgroundServices
{
    public class TestBackgroundService : BackgroundService
    {
        private readonly ILogger<TestBackgroundService> _logger;

        public TestBackgroundService(ILogger<TestBackgroundService> logger)
        {
            _logger = logger;
        }
          
        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            int count = 0;
            while (!stoppingToken.IsCancellationRequested)
            {
                var actor = new Actor();
                actor.Id = $"Id {count}";
                actor.Name = $"Actor {count}"; 
                string output = JsonConvert.SerializeObject(actor);
                var inputData = Encoding.UTF8.GetBytes(output);
                var resultData = Encoding.UTF8.GetString(inputData);
                Actor result = JsonConvert.DeserializeObject<Actor>(resultData);
                Console.WriteLine(result);
                await Task.Delay(3000, stoppingToken);
                count++;
            }
        }
    }
}

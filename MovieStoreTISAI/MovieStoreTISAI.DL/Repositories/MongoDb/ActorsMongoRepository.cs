using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.Models.Configuration;
using MovieStoreTISAI.Models.DTO;


namespace MovieStoreTISAI.DL.Repositories.MongoDb
{
    internal class ActorsMongoRepository : IActorRepository
    {
        private readonly IMongoCollection<Actor> _actorsCollection;
        private readonly ILogger<ActorsMongoRepository> _logger;
        public ActorsMongoRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<ActorsMongoRepository> logger)
        {
            _logger = logger;

            if (string.IsNullOrEmpty(mongoConfig?.CurrentValue?.ConnectionString) || string.IsNullOrEmpty(mongoConfig?.CurrentValue?.DatabaseName))
            {
                _logger.LogError("MongoDb ConnectionString is null or empty");
                throw new ArgumentNullException("MongoDb ConnectionString is null or empty");
            }

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            _actorsCollection = database.GetCollection<Actor>($"{nameof(Actor)}s");
        }
        //public void Add()
        //{
        //    movie.Id = Guid.NewGuid().ToString();
        //}

        public void Delete(string id)
        {
        }


        List<Actor> IActorRepository.GetAll()
        {
            return _actorsCollection.Find(m => true)
                .ToList();
        }

        Actor? IActorRepository.GetByID(string id)
        {
            throw new NotImplementedException();
        }
    }
}

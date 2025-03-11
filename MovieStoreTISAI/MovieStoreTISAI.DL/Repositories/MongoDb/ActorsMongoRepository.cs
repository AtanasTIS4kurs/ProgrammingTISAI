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

        public async Task Add(Actor actor)
        {
            if (actor == null)
            {
                _logger.LogError("Actor is null");
                return;
            }
            try
            {
                await _actorsCollection.InsertOneAsync(actor);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to add actor");
            }
        }

        public async Task Delete(string id)
        {
            await _actorsCollection.DeleteOneAsync(m => m.Id == id);
        }
        public async Task<List<Actor>> GetActors(List<string> id)
        {
            var result = await _actorsCollection.FindAsync(m => id.Contains(m.Id.ToString()));

            return await result.ToListAsync();
        }

        public async Task<List<Actor>> GetAll()
        {
            var result = await _actorsCollection.FindAsync(m => true);
                return result.ToList();
        }

        public async Task<Actor?> GetByID(string id)
        {
            var result = await _actorsCollection.FindAsync(m => m.Id == id);
            return result.FirstOrDefault();
        }

        public async Task Update(Actor actor)
        {
            await _actorsCollection.ReplaceOneAsync(m => m.Id == actor.Id, actor);
        }
    }
}

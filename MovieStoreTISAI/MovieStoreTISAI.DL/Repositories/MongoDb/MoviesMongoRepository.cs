

using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.Models.Configuration;
using MovieStoreTISAI.Models.DTO;

namespace MovieStoreTISAI.DL.Repositories.MongoDb
{
    internal class MoviesMongoRepository : IMovieRepository
    {   
        private readonly IMongoCollection<Movie> _moviesCollection;
        private readonly ILogger<MoviesMongoRepository> _logger;
        public MoviesMongoRepository(
            IOptionsMonitor<MongoDbConfiguration> mongoConfig,
            ILogger<MoviesMongoRepository> logger)
        {
            _logger = logger;

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(
                mongoConfig.CurrentValue.DatabaseName);
            _moviesCollection = database.GetCollection<Movie>(
                "MoviesDb");  
        }
        public void Delete(string id)
        {
        }

        public List<Movie> GetAll()
        {
            return _moviesCollection.Find(m=>true)
                .ToList();
        }

        public Movie? GetByID(string id)
        {
            throw new NotImplementedException();
        }
    }
}

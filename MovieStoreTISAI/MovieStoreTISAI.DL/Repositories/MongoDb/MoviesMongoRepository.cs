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

            if (string.IsNullOrEmpty(mongoConfig?.CurrentValue?.ConnectionString) || string.IsNullOrEmpty(mongoConfig?.CurrentValue?.DatabaseName))
            {
                _logger.LogError("MongoDb ConnectionString is null or empty");
                throw new ArgumentNullException("MongoDb ConnectionString is null or empty");
            }

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);
            _moviesCollection = database.GetCollection<Movie>($"{nameof(Movie)}s");
        }
        //public void Add()
        //{
        //    movie.Id = Guid.NewGuid().ToString();
        //}

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

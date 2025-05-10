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

        public void Add(Movie movie)
        {
            if (movie == null) {
                _logger.LogError("Movie is null");
                return;
            }
            try
            {
                _moviesCollection.InsertOne(movie);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to add movie");
            }
        }

        public void Add()
        {
          
            // movie.Id = Guid.NewGuid().ToString();
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
            if (string.IsNullOrEmpty(id))
            {
                _logger.LogError("MovieId is null or empty");
                return null;
            }
            return _moviesCollection
               .Find(m => m.Id == id)
               .FirstOrDefault();
        }

        public void Update(Movie movie)
        {
            _moviesCollection.ReplaceOne(m => m.Id == movie.Id, movie);
        }
    }
}

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

        public async Task Add(Movie movie)
        {
            if (movie == null) {
                _logger.LogError("Movie is null");
                return;
            }
            try
            {
              await  _moviesCollection.InsertOneAsync(movie);
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Failed to add movie");
            }
        }

        public async Task Delete(string id)
        {
            await _moviesCollection.DeleteOneAsync(m => m.Id == id);
        }

        public async Task<List<Movie>>  GetAll()
        {
            var result = await _moviesCollection.FindAsync(m => true);
                return result.ToList();
        }

        public async Task<Movie?> GetByID(string id)
        {
            var result = await _moviesCollection.FindAsync(m => m.Id == id);
            return  result.FirstOrDefault();
        }

        public async Task Update(Movie movie)
        {
           await _moviesCollection.ReplaceOneAsync(m => m.Id == movie.Id, movie);
        }
    }
}

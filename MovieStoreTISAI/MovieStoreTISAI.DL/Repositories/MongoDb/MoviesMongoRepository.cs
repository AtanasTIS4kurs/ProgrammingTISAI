﻿using Microsoft.Extensions.Logging;
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

        public MoviesMongoRepository(ILogger<MoviesMongoRepository> logger, IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            _logger = logger;

            if (string.IsNullOrEmpty(mongoConfig?.CurrentValue?.ConnectionString) || string.IsNullOrEmpty(mongoConfig?.CurrentValue?.DatabaseName))
            {
                _logger.LogError("MongoDb configuration is missing");

                throw new ArgumentNullException("MongoDb configuration is missing");
            }

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _moviesCollection = database.GetCollection<Movie>($"{nameof(Movie)}s");
        }

        public async Task AddMovie(Movie movie)
        {
            movie.Id = Guid.NewGuid().ToString();
            await _moviesCollection.InsertOneAsync(movie);
        }
        public async Task DeleteMovie(string id)
        {
            await _moviesCollection.DeleteOneAsync(m => m.Id == id);
        }

        public async Task<List<Movie>> GetMovies()
        {
            var result = await _moviesCollection.FindAsync(m => true);

            return await result.ToListAsync();
        }

        //public async Task<Movie?> GetMoviesById(string id)
        //{
        //    return await _moviesCollection.Find(m => m.Id == id).FirstOrDefaultAsync();
        //}
        public Movie? GetMoviesById(string id)
        {
            return _moviesCollection.Find(m => m.Id == id).FirstOrDefault();
        }

        protected async Task<IEnumerable<Movie?>> GetMoviesAfterDateTime(DateTime date)
        {
            var result = await _moviesCollection.FindAsync(m => m.DateInserted >= date);

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<Movie?>> FullLoad()
        {
            return await GetMovies();
        }

        public async Task<IEnumerable<Movie?>> DifLoad(DateTime lastExecuted)
        {
            return await GetMoviesAfterDateTime(lastExecuted);
        }
    }
}
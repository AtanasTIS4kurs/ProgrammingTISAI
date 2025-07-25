﻿using Microsoft.Extensions.Logging;
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

        public ActorsMongoRepository(ILogger<ActorsMongoRepository> logger, IOptionsMonitor<MongoDbConfiguration> mongoConfig)
        {
            _logger = logger;

            if (string.IsNullOrEmpty(mongoConfig?.CurrentValue?.ConnectionString) || string.IsNullOrEmpty(mongoConfig?.CurrentValue?.DatabaseName))
            {
                _logger.LogError("MongoDb configuration is missing");

                throw new ArgumentNullException("MongoDb configuration is missing");
            }

            var client = new MongoClient(mongoConfig.CurrentValue.ConnectionString);
            var database = client.GetDatabase(mongoConfig.CurrentValue.DatabaseName);

            _actorsCollection = database.GetCollection<Actor>($"{nameof(Actor)}s");
        }


        public async Task<IEnumerable<Actor?>> DifLoad(DateTime lastExecuted)
        {
            var result = await _actorsCollection.FindAsync(m => m.DateInserted >= lastExecuted);

            return await result.ToListAsync();
        }

        public async Task<IEnumerable<Actor?>> FullLoad()
        {
            return await GetAllActors();
        }

        public async Task<IEnumerable<Actor?>> GetAllActors()
        {
            var result = await _actorsCollection.FindAsync(m => true);

            return await result.ToListAsync();
        }

        public async Task<Actor?> GetById(string id)
        {
            var result = await _actorsCollection.FindAsync(m => m.Id == id);

            return await result.FirstOrDefaultAsync();
        }
    }
}

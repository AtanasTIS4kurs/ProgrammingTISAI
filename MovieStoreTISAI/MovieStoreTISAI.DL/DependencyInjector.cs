using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieStoreB.DL.Cache;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.DL.Kafka.KafkaCache;
using MovieStoreTISAI.DL.Kafka;
using MovieStoreTISAI.DL.Repositories;
using MovieStoreTISAI.DL.Repositories.MongoDb;
using MovieStoreTISAI.Models.DTO;
using MovieStoreB.DL.Repositories.MongoRepositories;
using MovieStoreTISAI.Models.Configuration.CachePopulator;

namespace MovieStoreTISAI.DL
{

    public static class DependencyInjection
    {
        public static IServiceCollection
            AddDataDependencies(this IServiceCollection services, IConfiguration config)
        {
            services.AddSingleton<IMovieRepository, MoviesMongoRepository>();
            services.AddSingleton<IActorRepository, ActorsMongoRepository>();


            services.AddCache<MoviesCacheConfiguration, MoviesMongoRepository, Movie, string>(config);


            services.AddCache<ActorsCacheConfiguration, ActorsMongoRepository, Actor, string>(config);

            services.AddHostedService<KafkaCache<string, Movie>>();

            //services.AddCache<ComposerCacheConfiguration, ComposerRepository, Composer, int>(config);

            return services;
        }
        public static IServiceCollection AddCache<TCacheConfiguration, TCacheRepository, TData, TKey>(this IServiceCollection services, IConfiguration config)
           where TCacheConfiguration : CacheConfiguration
           where TCacheRepository : class, ICacheRepository<TKey, TData>
           where TData : ICacheItem<TKey>
           where TKey : notnull
        {
            var configSection = config.GetSection(typeof(TCacheConfiguration).Name);

            if (!configSection.Exists())
            {
                throw new ArgumentNullException(typeof(TCacheConfiguration).Name, "Configuration section is missing in appsettings!");
            }

            services.Configure<TCacheConfiguration>(configSection);

            services.AddSingleton<ICacheRepository<TKey, TData>, TCacheRepository>();
            services.AddSingleton<IKafkaProducer<TData>, KafkaProducer<TKey, TData, TCacheConfiguration>>();
            services.AddHostedService<MongoCachePopulator<TData, TCacheConfiguration, TKey>>();

            return services;
        }
    }
}

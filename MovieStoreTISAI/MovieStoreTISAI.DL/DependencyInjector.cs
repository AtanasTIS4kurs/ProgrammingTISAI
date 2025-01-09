using Microsoft.Extensions.DependencyInjection;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.DL.Repositories;
using MovieStoreTISAI.DL.Repositories.MongoDb;

namespace MovieStoreTISAI.DL
{

    public static class DependencyInjection
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddSingleton<IMovieRepository, MoviesMongoRepository>()
                .AddSingleton<IActorRepository, ActorsMongoRepository>();
        }
    }
}

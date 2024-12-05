using Microsoft.Extensions.DependencyInjection;
using MovieStoreTISAI.DL.Interfaces;
using MovieStoreTISAI.DL.Repositories;

namespace MovieStoreTISAI.DL
{

    public static class DependencyInjection
    {
        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            return services
                .AddSingleton<IMovieRepository, MovieStaticDataRepository>()
                .AddSingleton<IActorRepository, ActorStaticDataRepository>();
        }
    }
}

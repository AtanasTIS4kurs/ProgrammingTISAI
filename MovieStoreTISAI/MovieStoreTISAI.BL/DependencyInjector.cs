using Microsoft.Extensions.DependencyInjection;
using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.BL.Services;

namespace MovieStoreTISAI.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection
            AddBusinessDependencies(this IServiceCollection services)
        {
            services.AddSingleton<IMovieService, MovieService>();

            return services;
        }
    }
}

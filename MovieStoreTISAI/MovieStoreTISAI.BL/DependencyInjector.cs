using Microsoft.Extensions.DependencyInjection;
using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.BL.Services;

namespace MovieStoreTISAI.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            return services.AddSingleton<IMoviesService, MoviesService>();
        }
    }
}

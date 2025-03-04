using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.Models.Configuration;

namespace MovieStoreTISAI.ServiceExtensions
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services.Configure<MongoDbConfiguration>(config.GetSection(nameof(MongoDbConfiguration)));
            return services;
        }
    }
}

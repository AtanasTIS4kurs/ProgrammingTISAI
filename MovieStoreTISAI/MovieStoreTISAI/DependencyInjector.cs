using Microsoft.Extensions.DependencyInjection;
using MovieStoreTISAI.BackgroundServices;
using MovieStoreTISAI.BL.Interfaces;
using MovieStoreTISAI.BL.Services;

namespace MovieStoreTISAI.BL
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddBackgroundServices(this IServiceCollection services)
        {
            services.AddHostedService<TestBackgroundService>();
            return services;
        }
        public static IServiceCollection AddHostedServices(this IServiceCollection services)
        {
            services.AddHostedService<TestHostedService>();
            return services;
        }
    }
}

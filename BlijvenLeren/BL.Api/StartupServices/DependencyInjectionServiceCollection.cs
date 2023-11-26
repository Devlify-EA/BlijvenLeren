using BL.Api.Authentication;
using BL.DAL;
using System.Diagnostics.CodeAnalysis;

namespace BL.Api.StartupServices
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjectionServiceCollection
    {
        public static IServiceCollection SetupConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IBlijvenLerenRepository, BlijvenLerenCosmosDbRepository>();            
            services.AddSingleton<IJwtManager>(new JwtManager(configuration["Jwt:Key"]));

            return services;
        }
    }
}

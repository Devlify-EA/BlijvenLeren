using BL.DAL;
using System.Diagnostics.CodeAnalysis;

namespace BL.Api.StartupServices
{
    [ExcludeFromCodeCoverage]
    public static class CosmosDbServiceCollection
    {
        public static IServiceCollection AddCosmosDb(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<AzureCosmosDbOptions>(
                options =>
                {
                    options.DatabaseId = configuration["CosmosDb:DatabaseId"];
                    options.PrimaryKey = configuration["CosmosDb:PrimaryKey"];
                    options.EndpointUri = configuration["CosmosDb:EndpointUri"];
                    options.ContainerName = configuration["CosmosDb:ContainerName"];
                });

            return services;
        }
    }
}

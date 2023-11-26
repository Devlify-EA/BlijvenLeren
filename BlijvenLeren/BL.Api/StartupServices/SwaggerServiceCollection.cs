using BL.Api.Swashbuckle;
using Microsoft.OpenApi.Models;
using System.Diagnostics.CodeAnalysis;

namespace BL.Api.StartupServices
{
    [ExcludeFromCodeCoverage]
    public static class SwaggerServiceCollection
    {
        public static IServiceCollection AddSwaggerGen(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo { Title = "BlijvenLeren Api", Version = "v1" });
                options.SwaggerDoc("v2", new OpenApiInfo { Title = "BlijvenLeren Api", Version = "v2" });
                options.SchemaFilter<SwaggerExcludePropertySchemaFilter>();
            });

            return services;
        }
    }
}

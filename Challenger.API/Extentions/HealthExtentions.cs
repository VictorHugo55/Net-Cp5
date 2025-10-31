using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace WebApplication2.API.Extentions;

public static class HealthExtentions
{
    public static IServiceCollection AddHealthServices(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddHealthChecks()
            .AddMySql(configuration.GetConnectionString("MotoGridDB"), name: "MotoGridDB")
            .AddMongoDb()
            .AddUrlGroup(new Uri("https://fiap.com.br"), "FIAP")
            .AddUrlGroup(new Uri("https://viacep.com.br/"), name: "VIA CEP");
        
        return services;
    }
}
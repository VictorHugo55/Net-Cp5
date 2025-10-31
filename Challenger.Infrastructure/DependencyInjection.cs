using Challenger.Application.Configs;
using Challenger.Domain.Interfaces;
using Challenger.Infrastructure.Context;
using Challenger.Infrastructure.MongoDB;
using Challenger.Infrastructure.Percistence.Repositoryes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

using ConnectionSettings = Challenger.Application.Configs.ConnectionSettings;
using ServerVersion = Microsoft.EntityFrameworkCore.ServerVersion;

namespace Challenger.Infrastructure
{
    public static class DependencyInjection
    {
        private static IServiceCollection AddDBContext(this IServiceCollection services, ConnectionSettings configuration)
        {
            return services.AddDbContext<CGContext>(options =>
            {
                var connectionString = configuration.MotoGridDb;
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), my =>
                {
                    my.EnableRetryOnFailure();
                });
            });
        }

        private static IServiceCollection AddMongoDB(this IServiceCollection services)
        {
            services.AddScoped<MongoContext>();
            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IMotoRepository, MotoRepository>();
            services.AddScoped<IPatioRepository, PatioRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddInfra(this IServiceCollection services, Settings settings)
        {
            services.AddDBContext(settings.ConnectionStrings);
            services.AddRepositories();
            services.AddMongoDB();
            return services;
        }
    }
}

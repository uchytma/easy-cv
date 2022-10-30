using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Infrastructure.Repositories;
using EasyCv.Infrastructure.Storage.SQlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace EasyCv.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureServicesSQlite(this IServiceCollection services, Action<DbContextOptionsBuilder> dbOptions)
        {
            services.AddInfrastructureDbServices(dbOptions);
            services.AddSingleton<IResumeRepository, ResumeRepositorySQlite>();
            services.AddSingleton<IResumeSecurityKeyRepository, ResumeSecurityKeyRepositorySQlite>();
            return services;
        }

        public static IServiceCollection AddInfrastructureServicesAzureTableStorage(this IServiceCollection services, Action<DbContextOptionsBuilder> dbOptions)
        {

            return services;
        }
    }
}

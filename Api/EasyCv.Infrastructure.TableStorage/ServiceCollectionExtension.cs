
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Infrastructure.Storage.AzureTableStorage
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureAzureTableStorage(this IServiceCollection services, StorageConfiguration cfg)
        {
            services.AddSingleton<StorageConfiguration>(cfg);
            services.AddSingleton<StorageFactory>();
            return services;
        }
    }
}

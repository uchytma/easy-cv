using EasyCv.Infrastructure.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Infrastructure
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddInfrastructureDbServices(this IServiceCollection services, Action<DbContextOptionsBuilder> dbOptions)
        {
            services.AddDbContextFactory<EasyCvContext>(opts => dbOptions(opts));
            return services;
        }
    }
}

using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain.Services;
using EasyCv.Infrastructure.Repositories;
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
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, Action<DbContextOptionsBuilder> dbOptions)
        {
            services.AddInfrastructureDbServices(dbOptions);
            services.AddSingleton<IResumeRepository, ResumeRepositorySQlite>();
            services.AddSingleton<IResumeSecurityKeyRepository, ResumeSecurityKeyRepositorySQlite>();
            return services;
        }
    }
}

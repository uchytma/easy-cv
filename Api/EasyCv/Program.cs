using EasyCv.Api.GraphQL.Types;
using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain.Services;
using EasyCv.Infrastructure;
using EasyCv.Infrastructure.Storage.AzureTableStorage;
using EasyCv.Infrastructure.Storage.SQlite.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyCv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            ConfigureInfrastructure(builder);
    
            builder.Services.AddSingleton<IResumeProvider, ResumeProvider>();

            builder.Services
                .AddGraphQLServer()
                .AddQueryType<QueryType>()
                .AddMutationType<MutationType>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL();
                endpoints.MapFallbackToFile("./index.html", new StaticFileOptions());
            });

            app.Run();
        }

        private static void ConfigureInfrastructure(WebApplicationBuilder builder)
        {
            string connSQlite = builder.Configuration.GetConnectionString("SQlite");
            if (!string.IsNullOrEmpty(connSQlite))
            {
                builder.Services.AddInfrastructureServicesSQlite(opt => ApplySqliteOptions(opt, connSQlite));
                return;
            }
            string connStringTableStorage = builder.Configuration.GetConnectionString("AzureTableStorage");
            if (!string.IsNullOrEmpty(connStringTableStorage))
            {
                var cfg = new StorageConfiguration(connStringTableStorage, "easycvtest");
                builder.Services.AddInfrastructureServicesAzureTableStorage(cfg);
                return;
            }
            throw new ConnectionStringNotSpecifiedException();
        }

        /// <summary>
        /// </summary>
        /// <param name="opts"></param>
        private static void ApplySqliteOptions(DbContextOptionsBuilder opts, string connString)
        {
            if (string.IsNullOrEmpty(connString)) throw new ConnectionStringNotSpecifiedException();
            opts.UseSqlite(connString);
        }
    }
}
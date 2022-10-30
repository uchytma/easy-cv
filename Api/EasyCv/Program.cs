using EasyCv.Api.GraphQL.Types;
using EasyCv.Core.ResumeDomain.Services;
using EasyCv.Infrastructure;
using EasyCv.Infrastructure.Storage.AzureTableStorage;
using EasyCv.Infrastructure.Storage.SQlite.Exceptions;
using Microsoft.EntityFrameworkCore;

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
            //SQlite
            var configSQlite = builder.Configuration.GetSection("Storages:SQlite");
            var connSQlite = configSQlite["ConnectionString"];
            if (!string.IsNullOrEmpty(connSQlite))
            {
                builder.Services.AddInfrastructureServicesSQlite(opt => opt.UseSqlite(connSQlite));
                return;
            }

            //Azure table storage
            var configAzureTable = builder.Configuration.GetSection("Storages:AzureTableStorage");
            string connStringTableStorage = configAzureTable["ConnectionString"];
            string tableName = configAzureTable["TableName"];
            if (!string.IsNullOrEmpty(connStringTableStorage))
            {
                var cfg = new StorageConfiguration(connStringTableStorage, tableName);
                builder.Services.AddInfrastructureServicesAzureTableStorage(cfg);
                return;
            }
            throw new ConnectionStringNotSpecifiedException();
        }
    }
}
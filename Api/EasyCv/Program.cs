using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain.Services;
using GraphQL;
using EasyCv.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace EasyCv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddGraphQL(b => b
                .AddAutoSchema<Query>() 
                .AddSystemTextJson());

            builder.Services.AddInfrastructureServices(opt => ApplySqliteOptions(opt));
            builder.Services.AddSingleton<IResumeProvider, ResumeProvider>();
           
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
                endpoints.MapGraphQL("graphql");
                endpoints.MapGraphQLGraphiQL("graphql/ui");
                endpoints.MapFallbackToFile("./index.html", new StaticFileOptions());
            });

            app.Run();
        }

        private static void ApplySqliteOptions(DbContextOptionsBuilder opts)
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            var dbPath = System.IO.Path.Join(path, "easycv.db");
            opts.UseSqlite(($"Data Source=.\\easycv.db"));
        }


        public class Query
        {
            public static string Hello() => "Hello from QraphQL server!";
        }
    }
}
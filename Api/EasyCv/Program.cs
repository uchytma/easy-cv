using EasyCv.Api.GraphQL.Types;
using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain.Services;
using EasyCv.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EasyCv
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
 
            builder.Services.AddInfrastructureServices(opt => ApplySqliteOptions(opt, builder));
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

   
        private static void ApplySqliteOptions(DbContextOptionsBuilder opts, WebApplicationBuilder builder)
        {
            string connString = builder.Configuration.GetConnectionString("EasyCv");
            opts.UseSqlite(connString);
        }
    }
}
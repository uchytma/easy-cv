using EasyCv.Api.GraphQL.Types;
using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain.Services;
using EasyCv.Infrastructure;
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
 
            builder.Services.AddInfrastructureServicesSQlite(opt => ApplySqliteOptions(opt, builder));
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

   
        /// <summary>
        /// </summary>
        /// <param name="opts"></param>
        /// <param name="builder"></param>
        /// <exception cref="ConnectionStringNotSpecifiedException">Throws when conn string with name EasyCv is not found.</exception>
        private static void ApplySqliteOptions(DbContextOptionsBuilder opts, WebApplicationBuilder builder)
        {
            string connString = builder.Configuration.GetConnectionString("EasyCv");
            if (string.IsNullOrEmpty(connString)) throw new ConnectionStringNotSpecifiedException();
            opts.UseSqlite(connString);
        }
    }
}
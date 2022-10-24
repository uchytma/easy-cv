using GraphQL;

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


        public class Query
        {
            public static string Hello() => "Hello from QraphQL server!";
        }
    }
}
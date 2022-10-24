using Microsoft.Extensions.FileProviders;

namespace EasyCv.Api.Extensions
{
    public static class WebApplicationExtensions
    {
        /// <summary>
        /// Serve Single Page Application static files from wwwroot/app.
        /// Adds "index.html" as default file.
        /// </summary>
        /// <param name="app"></param>
        public static void ServeSpaFiles(this WebApplication app)
        {
            var spaFilesProvider = new PhysicalFileProvider(Path.Combine(app.Environment.WebRootPath, "app"));
            app.UseDefaultFiles(new DefaultFilesOptions
            {
                FileProvider = spaFilesProvider,
                RequestPath = "",
                DefaultFileNames = new[] { "index.html" },
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = spaFilesProvider,
                RequestPath = ""
            });
        }
    }
}

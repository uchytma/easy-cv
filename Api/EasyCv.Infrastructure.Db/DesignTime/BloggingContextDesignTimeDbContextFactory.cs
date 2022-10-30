using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyCv.Infrastructure.Storage.SQlite.DesignTime
{
    /// <summary>
    /// Only for dev purposes
    /// </summary>
    public class BloggingContextFactory : IDesignTimeDbContextFactory<EasyCvContext>
    {
        public EasyCvContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EasyCvContext>();
            optionsBuilder.UseSqlite();
            return new EasyCvContext(optionsBuilder.Options);
        }
    }
}
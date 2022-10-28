using EasyCv.Infrastructure.Db.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace EasyCv.Infrastructure.Db
{
    public class EasyCvContext : DbContext
    {
        public EasyCvContext(DbContextOptions<EasyCvContext> options) : base(options)
        {
        }

        public EasyCvContext()
        {
        }

        public DbSet<Resume> Resumes { get; set; } = default!;
    }


    /// <summary>
    /// Only for dev purposes
    /// </summary>
    public class BloggingContextFactory : IDesignTimeDbContextFactory<EasyCvContext>
    {
        public EasyCvContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<EasyCvContext>();
            optionsBuilder.UseSqlite("Data Source=C:\\dev\\easycv\\easycv.db");

            return new EasyCvContext(optionsBuilder.Options);
        }
    }
}
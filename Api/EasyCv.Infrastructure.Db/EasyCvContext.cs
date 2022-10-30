using EasyCv.Infrastructure.Storage.SQlite.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyCv.Infrastructure.Storage.SQlite
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
}
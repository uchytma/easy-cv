using EasyCv.Infrastructure.Db.Entities;
using Microsoft.EntityFrameworkCore;

namespace EasyCv.Infrastructure.Db
{
    public class EasyCvContext : DbContext
    {
        public DbSet<Resume> Resumes { get; set; } = default!;
    }
}
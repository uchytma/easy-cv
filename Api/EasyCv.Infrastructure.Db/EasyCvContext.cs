using EasyCv.Infrastructure.Db.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace EasyCv.Infrastructure.Db
{
    public class EasyCvContext : DbContext
    {
        public DbSet<Resume> Resumes { get; set; } = default!;

        public string DbPath { get; }

        public EasyCvContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            DbPath = System.IO.Path.Join(path, "easycv.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");
    }
}
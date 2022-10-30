using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain;
using EasyCv.Core.ResumeDomain.Exceptions;
using EasyCv.Infrastructure.Storage.SQlite;
using Microsoft.EntityFrameworkCore;

namespace EasyCv.Infrastructure.Repositories
{
    internal class ResumeSecurityKeyRepositorySQlite : IResumeSecurityKeyRepository
    {
        private readonly IDbContextFactory<EasyCvContext> _dbContextFactory;

        public ResumeSecurityKeyRepositorySQlite(IDbContextFactory<EasyCvContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task<Guid> GetResumeSecurityKey(Resume resume)
        {
            using var db = _dbContextFactory.CreateDbContext();
            var r = await db.Resumes.FindAsync(resume.Id);
            if (r is null || r.SecurityKey is null) throw new SecurityKeyNotFoundException();
            return r.SecurityKey.Value;
        }

        public async Task SetResumeSecurityKey(Resume resume, Guid editKey)
        {
            using var db = _dbContextFactory.CreateDbContext();
            var r = await db.Resumes.FindAsync(resume.Id);
            if (r is null) throw new ResumeNotFoundException();
            r.SecurityKey = editKey;
            await db.SaveChangesAsync();
        }
    }
}

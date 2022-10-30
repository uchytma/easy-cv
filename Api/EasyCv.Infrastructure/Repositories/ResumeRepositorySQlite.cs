﻿using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain.Exceptions;
using EasyCv.Infrastructure.Storage.SQlite;
using Microsoft.EntityFrameworkCore;

namespace EasyCv.Infrastructure.Repositories
{
    internal class ResumeRepositorySQlite : IResumeRepository
    {
        private readonly IDbContextFactory<EasyCvContext> _dbContextFactory;

        public ResumeRepositorySQlite(IDbContextFactory<EasyCvContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task Create(Core.ResumeDomain.Resume resume)
        {
            using var db = _dbContextFactory.CreateDbContext();
            db.Resumes.Add(new Storage.SQlite.Entities.Resume() { Id = resume.Id, Email = resume.Email, JsonData = resume.JsonData });
            await db.SaveChangesAsync();
        }

        public async Task<Core.ResumeDomain.Resume> GetById(Guid id)
        {
            using var db = _dbContextFactory.CreateDbContext();
            var r = await db.Resumes.FindAsync(id);
            if (r is null) throw new ResumeNotFoundException();
            return new Core.ResumeDomain.Resume(r.Id!.Value, r.Email, r.JsonData);
        }

        public async Task Update(Core.ResumeDomain.Resume resume)
        {
            using var db = _dbContextFactory.CreateDbContext();
            var r = await db.Resumes.FindAsync(resume.Id);
            if (r is null) throw new ResumeNotFoundException();
            r.Email = resume.Email;
            r.JsonData = resume.JsonData;
            await db.SaveChangesAsync();
        }
    }
}

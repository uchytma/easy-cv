using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain;
using EasyCv.Core.ResumeDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Core.Tests.DummyRepos
{
    /// <summary>
    /// Not thread safe!
    /// Do not use asynchronously!
    /// </summary>
    internal class ResumeRepositoryInMemory : IResumeRepository
    {
        private List<Resume> _resumes = new List<Resume>();

        public Task Create(Resume resume)
        {
            _resumes.Add(resume);
            return Task.CompletedTask;
        }

        public Task<Resume> GetById(Guid id)
        {
            return Task.FromResult(_resumes.SingleOrDefault(d => d.Id == id) ?? throw new ResumeNotFoundException());
        }

        public async Task Update(Resume resume)
        {
            Resume? existingResume = null;
            try
            {
                existingResume = await GetById(resume.Id);
                _resumes.RemoveAll((d) => d == existingResume);
            }
            catch (ResumeNotFoundException)
            {
                //not found, nothing to remove
            }
            _resumes.Add(resume);
        }
    }
}


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
    internal class ResumeSecurityKeyRepositoryInMemory : IResumeSecurityKeyRepository
    {
        /// <summary>
        /// Key: Resume Id
        /// Value: Resume security key
        /// </summary>
        private Dictionary<Guid, Guid> _keysForResumes = new Dictionary<Guid, Guid>();
        public Task<Guid> GetResumeSecurityKey(Resume resume)
        {
            if (!_keysForResumes.TryGetValue(resume.Id, out Guid val))
                throw new SecurityKeyNotFoundException();
            return Task.FromResult(val);
        }

        public Task SetResumeSecurityKey(Resume resume, Guid editKey)
        {
            _keysForResumes[resume.Id] = editKey;
            return Task.CompletedTask;
        }
    }
}

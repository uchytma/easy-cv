using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Core.ResumeDomain.Services
{

    public class ResumeProvider : IResumeProvider
    {
        private readonly IResumeRepository _repo;
        private readonly IResumeSecurityKeyRepository _repoSecurityKey;

        public ResumeProvider(IResumeRepository repo, 
            IResumeSecurityKeyRepository repoSecurityKey)
        {
            _repo = repo;
            _repoSecurityKey = repoSecurityKey;
        }

        public Task<Resume> GetById(Guid id)
        {
            return _repo.GetById(id);
        }

        public async Task<(Resume Resume, Guid SecurityKey)> Create(string email, string jsonData)
        {
            Guid securityKey = Guid.NewGuid();

            Guid guid = Guid.NewGuid();
            await _repo.Create(new Resume(guid, email, jsonData));
            var resume = await GetById(guid);
            await _repoSecurityKey.SetResumeSecurityKey(resume, securityKey);
            return (resume, securityKey);
        }

        public async Task Update(Resume resume)
        {
            await _repo.Update(resume);
        }

        public async Task<bool> SecurityKeyIsValid(Guid securityKey, Resume resume)
        {
            var secKey = await _repoSecurityKey.GetResumeSecurityKey(resume);
            return secKey == securityKey;
        }
    }
}

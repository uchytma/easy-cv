using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Infrastructure.Repositories
{
    internal class ResumeRepositorySQlite : IResumeRepository
    {
        public Task Create(Resume resume)
        {
            throw new NotImplementedException();
        }

        public Task<Resume> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Resume resume)
        {
            throw new NotImplementedException();
        }
    }
}

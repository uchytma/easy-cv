using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Infrastructure.Repositories
{
    public class ResumeSecurityKeyRepositorySQlite : IResumeSecurityKeyRepository
    {
        public Task<Guid> GetResumeSecurityKey(Resume resume)
        {
            throw new NotImplementedException();
        }

        public Task SetResumeSecurityKey(Resume resume, Guid editKey)
        {
            throw new NotImplementedException();
        }
    }
}

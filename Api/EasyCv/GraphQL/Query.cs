using EasyCv.Core.ResumeDomain;
using EasyCv.Core.ResumeDomain.Services;

namespace EasyCv.Api.GraphQL
{
    public class Query
    {

        /// <summary>
        /// Gets resume object by Id.
        /// </summary>
        /// <param name="resumeProvider"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public Task<Resume> GetResumeById([Service] IResumeProvider resumeProvider, Guid id)
        {
            return resumeProvider.GetById(id);
        }
    }
}

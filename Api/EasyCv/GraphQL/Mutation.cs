using EasyCv.Core.ResumeDomain;
using EasyCv.Core.ResumeDomain.Services;

namespace EasyCv.Api.GraphQL
{
    public class Mutation
    {
        public async Task<ResumeAddedPayload> AddResume([Service] IResumeProvider resumeProvider, string email, string jsonData)
        {
            var res = await resumeProvider.Create(email, jsonData);
            return new ResumeAddedPayload(res.Resume, res.SecurityKey);
        }
    }

    public record ResumeAddedPayload(Resume Resume, Guid SecurityKey);
}

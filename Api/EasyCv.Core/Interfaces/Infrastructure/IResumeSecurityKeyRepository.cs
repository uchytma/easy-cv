using EasyCv.Core.ResumeDomain;

namespace EasyCv.Core.Interfaces.Infrastructure
{
    public interface IResumeSecurityKeyRepository
    {
        /// <summary>
        /// Returns security key for specified resume.
        /// </summary>
        /// <param name="resume"></param>
        /// <exception cref="ResumeDomain.Exceptions.SecurityKeyNotFoundException">Security key not found</exception>
        /// <returns></returns>
        public Task<Guid> GetResumeSecurityKey(Resume resume);

        /// <summary>
        /// Set secutiry key for specified resume.
        /// If Resume already has a key; it will be overwritten.
        /// </summary>
        /// <exception cref="ResumeDomain.Exceptions.ResumeNotFoundException">Resume does not exist</exception>
        /// <param name="resume"></param>
        /// <param name="securityKey"></param>
        public Task SetResumeSecurityKey(Resume resume, Guid securityKey);
    }
}

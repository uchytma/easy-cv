using EasyCv.Core.ResumeDomain.Exceptions;

namespace EasyCv.Core.ResumeDomain.Services
{
    public interface IResumeProvider
    {
        /// <summary>
        /// Create new Resume and set its security key.
        /// </summary>
        /// <exception cref="SecurityKeyIsNotValidException">Throws exception, if provided security key is not valid.</exception>
        /// <param name="email"></param>
        /// <param name="jsonData"></param>
        /// <param name="securityKey">Must be non-empty Guid</param>
        /// <returns>Created resume object</returns>
        Task<Resume> Create(string email, string jsonData, Guid securityKey);

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ResumeNotFoundException"></exception>
        /// <param name="id"></param>
        Task<Resume> GetById(Guid id);

        /// <summary>
        /// Returns true, if provided security key is valid.
        /// </summary>
        /// <param name="securityKey"></param>
        /// <param name="resume"></param>
        /// <exception cref="SecurityKeyNotFoundException"></exception>
        /// <returns></returns>
        Task<bool> SecurityKeyIsValid(Guid securityKey, Resume resume);

        /// <summary>
        /// 
        /// </summary>
        /// <exception cref="ResumeNotFoundException"></exception>
        /// <param name="resume"></param>
        /// <returns></returns>
        Task Update(Resume resume);
    }
}

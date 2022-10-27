using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyCv.Core.ResumeDomain;

namespace EasyCv.Core.Interfaces.Infrastructure
{
    public interface IResumeRepository
    {
        /// <summary>
        /// Returns resume specified by unique Id.
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="ResumeDomain.Exceptions.ResumeNotFoundException">Resume does not found</exception>
        /// <returns></returns>
        public Task<Resume> GetById(Guid id);

        /// <summary>
        /// Create new resume.
        /// </summary>
        /// <param name="resume"></param>
        /// <returns></returns>
        public Task Create(Resume resume);

        /// <summary>
        /// Update existing resume.
        /// </summary>
        /// <param name="resume"></param>
        /// <exception cref="ResumeDomain.Exceptions.ResumeNotFoundException">Resume does not found</exception>
        /// <returns></returns>
        public Task Update(Resume resume);
    }
}

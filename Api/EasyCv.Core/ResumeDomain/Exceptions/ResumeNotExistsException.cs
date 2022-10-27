using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Core.ResumeDomain.Exceptions
{
    public class ResumeNotFoundException : ApplicationException
    {
        public ResumeNotFoundException() : base("Resume not found.")
        {
        }
    }
}

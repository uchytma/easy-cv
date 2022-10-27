using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Core.ResumeDomain.Exceptions
{
    public class SecurityKeyIsNotValidException : ApplicationException
    {
        public SecurityKeyIsNotValidException() : base("Security key is not valid.")
        {
        }
    }
}

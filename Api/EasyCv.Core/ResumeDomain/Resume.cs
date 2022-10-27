using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Core.ResumeDomain
{
    public class Resume
    {
        public Resume(Guid id, string email, string jsonData)
        {
            Id = id;
            Email = email;
            JsonData = jsonData;
        }
        public Guid Id { get; }
        public string Email { get; }
        public string JsonData { get; set; }
    }
}

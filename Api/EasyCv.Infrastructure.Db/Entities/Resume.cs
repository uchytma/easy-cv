using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Infrastructure.Storage.SQlite.Entities
{
    public class Resume
    {
        public Guid? Id { get; set; }

        public Guid? SecurityKey { get; set; }

        public string Email { get; set; } = default!;

        public string JsonData { get; set; } = default!;
    }
}

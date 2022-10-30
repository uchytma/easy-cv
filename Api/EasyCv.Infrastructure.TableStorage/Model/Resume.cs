using Azure;
using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Infrastructure.Storage.AzureTableStorage.Model
{
    public class Resume : ITableEntity
    {
        public Guid Id { get; set; }
        public Guid? SecurityKey { get; set; }
        public string Email { get; set; } = default!;
        public string JsonData { get; set; } = default!;

        public string PartitionKey { get; set; } = default!;
        public string RowKey { get; set; } = default!;
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; } = default!;
    }
}

using Azure.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCv.Infrastructure.Storage.AzureTableStorage
{
    public class StorageFactory
    {
        private readonly StorageConfiguration _cfg;

        public StorageFactory(StorageConfiguration cfg)
        {
            _cfg = cfg;
        }

        public async Task<TableClient> GetTableClient()
        {
            var serviceClient = new TableServiceClient(_cfg.ConnectionString);
            var tableClient = serviceClient.GetTableClient(_cfg.TableName);
            await tableClient.CreateIfNotExistsAsync();
            return tableClient;
        }
    }
}

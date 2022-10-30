using EasyCv.Core.Interfaces.Infrastructure;
using EasyCv.Core.ResumeDomain.Exceptions;
using EasyCv.Infrastructure.Storage.AzureTableStorage;
using EasyCv.Infrastructure.Storage.AzureTableStorage.Model;
using Azure;
using Azure.Data.Tables;

namespace EasyCv.Infrastructure.Repositories
{
    internal class AzureTableRepo : IResumeRepository, IResumeSecurityKeyRepository
    {
        private const string _partitionKey = "resume";

        private readonly StorageFactory _factory;

        public AzureTableRepo(StorageFactory factory)
        {
            _factory = factory;
        }

        public async Task Create(Core.ResumeDomain.Resume resume)
        {
            var client = await _factory.GetTableClient();
            await client.AddEntityAsync(GetResumeDbObject(resume));
        }

        public async Task<Core.ResumeDomain.Resume> GetById(Guid id)
        {
            var client = await _factory.GetTableClient();
            var response = await GetResumeFromTableService(client, id);
            return new Core.ResumeDomain.Resume(response.Id, response.Email, response.JsonData);
        }

        public async Task<Guid> GetResumeSecurityKey(Core.ResumeDomain.Resume resume)
        {
            var client = await _factory.GetTableClient();
            try
            {
                var response = await GetResumeFromTableService(client, resume.Id);
                return response.SecurityKey ?? throw new SecurityKeyNotFoundException();
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404) throw new SecurityKeyNotFoundException();
                throw;
            }
            catch (SecurityKeyNotFoundException)
            {
                throw;
            }
        }

        public async Task SetResumeSecurityKey(Core.ResumeDomain.Resume resume, Guid securityKey)
        {
            var client = await _factory.GetTableClient();
            var response = await GetResumeFromTableService(client, resume.Id);
            response.SecurityKey = securityKey;
            await client.UpsertEntityAsync(response);
        }

        public async Task Update(Core.ResumeDomain.Resume resume)
        {
            var client = await _factory.GetTableClient();
            await client.UpdateEntityAsync(GetResumeDbObject(resume), ETag.All);
        }

        private static async Task<Resume> GetResumeFromTableService(TableClient client, Guid id)
        {
            try
            {
                var response = (await client.GetEntityAsync<Resume>(_partitionKey, id.ToString())).Value;
                return response;
            }
            catch (RequestFailedException ex)
            {
                if (ex.Status == 404) throw new ResumeNotFoundException();
                throw;
            }
        }
        private static Resume GetResumeDbObject(Core.ResumeDomain.Resume resume)
        {
            return new Resume()
            {
                Id = resume.Id,
                Email = resume.Email,
                JsonData = resume.JsonData,
                PartitionKey = _partitionKey,
                RowKey = resume.Id.ToString()
            };
        }
    }
}

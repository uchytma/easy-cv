namespace EasyCv.Infrastructure.Storage.AzureTableStorage
{
    public record StorageConfiguration(string ConnectionString, string TableName);
}

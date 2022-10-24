using MongoDB.Driver;

namespace plants_for_cats.DataLayer
{
    public interface IMongoHelper
    {
        Task<List<T>> GetAllDocuments<T>(string dbName, string collectionName);
        Task<List<T>> GetFilteredDocuments<T>(string dbName, string collectionName, FilterDefinition<T> filter);
        Task UpdateDocument<T>(string dbName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> document);
        Task CreateDocument<T>(string dbName, string collectionName, T document);
        Task DeleteDocument<T>(string dbName, string collectionName, FilterDefinition<T> filter);
    }
}

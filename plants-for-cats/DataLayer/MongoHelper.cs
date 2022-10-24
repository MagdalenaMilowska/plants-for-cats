using MongoDB.Driver;

namespace plants_for_cats.DataLayer
{
    public class MongoHelper : IMongoHelper
    {
        private readonly IConfiguration _configuration;
        public MongoHelper(IConfiguration config)
        {
            _configuration = config;
        }

        public IMongoDatabase GetMongoDbInstance(string dbName)
        {
            var connString = _configuration.GetConnectionString("MongoDB");
            var client = new MongoClient(connString);
            var db = client.GetDatabase(dbName);
            return db;
        }

        private IMongoCollection<T> GetCollection<T>(string dbName, string collectionName)
        {
            return GetMongoDbInstance(dbName).GetCollection<T>(collectionName);
        }


        public async Task CreateDocument<T>(string dbName, string collectionName, T document)
        {
            await GetCollection<T>(dbName, collectionName).InsertOneAsync(document);
        }

        public async Task DeleteDocument<T>(string dbName, string collectionName, FilterDefinition<T> filter)
        {
            await GetCollection<T>(dbName, collectionName).DeleteOneAsync(filter);
        }

        public async Task<List<T>> GetAllDocuments<T>(string dbName, string collectionName)
        {
            var collection = GetCollection<T>(dbName, collectionName);
            return await collection.Find(x => true).ToListAsync();
        }

        public async Task<List<T>> GetFilteredDocuments<T>(string dbName, string collectionName, FilterDefinition<T> filter)
        {
            return await GetCollection<T>(dbName, collectionName).Find(filter).ToListAsync();
        }

        public Task UpdateDocument<T>(string dbName, string collectionName, FilterDefinition<T> filter, UpdateDefinition<T> document)
        {
            return GetCollection<T>(dbName, collectionName).UpdateOneAsync(filter, document);
        }
    }
}

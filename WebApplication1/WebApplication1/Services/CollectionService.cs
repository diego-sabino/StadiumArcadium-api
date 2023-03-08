using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class CollectionService<T> where T : IEntity
    {
        private readonly IMongoCollection<T> _collection;

        protected CollectionService(IOptions<DBSettings> dbSettings, string collectionName)
        {
            var mongoClient = new MongoClient(dbSettings.Value.ConnectionString);
            var mongoDatabase = mongoClient.GetDatabase(dbSettings.Value.DatabaseName);

            _collection = mongoDatabase.GetCollection<T>(collectionName);
        }

        public async Task<List<T>> GetAsync() =>
            await _collection.Find(x => true).ToListAsync();
        public async Task<T> GetAsync(string id) =>
            await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
        public async Task CreateAsync(T item) =>
            await _collection.InsertOneAsync(item);
        public async Task UpdateAsync(string id, T updatedItem) =>
            await _collection.ReplaceOneAsync(x => x.Id == id, updatedItem);
        public async Task RemoveAsync(string id) =>
            await _collection.DeleteOneAsync(x => x.Id == id);
    }

    public interface IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        string Id { get; set; }
    }
}
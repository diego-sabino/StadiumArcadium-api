using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class SongServices
{
    private readonly IMongoCollection<Song> _collection;

    public SongServices(IOptions<SongDBSettings> songServices)
    {
        var mongoClient = new MongoClient(songServices.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(songServices.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Song>(songServices.Value.SongCollectionName);
    }
    
    public async Task<List<Song>> GetAsync() =>
        await _collection.Find(x => true).ToListAsync();
    public async Task<Song> GetAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(Song song) =>
        await _collection.InsertOneAsync(song);
    public async Task UpdateAsync(string id, Song song) =>
        await _collection.ReplaceOneAsync(x => x.Id == id, song);
    public async Task RemoveAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}
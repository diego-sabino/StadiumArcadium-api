using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class AlbumsServices
{
    private readonly IMongoCollection<Album> _collection;
    public AlbumsServices(IOptions<AlbumDBSettings> albumDBSettings)
    {
        var mongoClient = new MongoClient(albumDBSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(albumDBSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Album>(albumDBSettings.Value.AlbumCollectionName);
    }
    
    public async Task<List<Album>> GetAsync() =>
        await _collection.Find(x => true).ToListAsync();
    public async Task<Album> GetAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(Album album) =>
        await _collection.InsertOneAsync(album);
    public async Task UpdateAsync(string id, Album updatedAlbum) =>
        await _collection.ReplaceOneAsync(x => x.Id == id, updatedAlbum);
    public async Task RemoveAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}
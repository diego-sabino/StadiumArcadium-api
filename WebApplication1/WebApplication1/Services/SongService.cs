using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using WebApplication1.Models;

namespace WebApplication1.Services;

public class SongServices
{
    private readonly IMongoCollection<Song> _collection;
    public SongServices(IOptions<SongDBSettings> songDBSettings)
    {
        var mongoClient = new MongoClient(songDBSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(songDBSettings.Value.DatabaseName);

        _collection = mongoDatabase.GetCollection<Song>(songDBSettings.Value.SongCollectionName);
    }
    
    public async Task<List<Song>> GetAsync() =>
        await _collection.Find(x => true).ToListAsync();
    public async Task<Song> GetAsync(string id) =>
        await _collection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(Song song) =>
        await _collection.InsertOneAsync(song);
    public async Task UpdateAsync(string id, Song updatedSong) =>
        await _collection.ReplaceOneAsync(x => x.Id == id, updatedSong);
    public async Task RemoveAsync(string id) =>
        await _collection.DeleteOneAsync(x => x.Id == id);
}
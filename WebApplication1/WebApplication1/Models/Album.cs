using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebApplication1.Services;

namespace WebApplication1.Models;

public class Album : IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("title")]
    public string Title { get; set; }
    
    [BsonElement("releaseDate")]
    public DateTime ReleaseDate { get; set; }
    
    [BsonElement("genre")]
    public string Genre { get; set; }
    
    [BsonElement("url")]
    public string Url { get; set; }
    
    [BsonElement("description")]
    public string Description { get; set; }
}
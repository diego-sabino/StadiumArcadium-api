using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Models;

public class Album
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
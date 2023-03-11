using MongoDB.Bson.Serialization.Attributes;
using WebApplication1.Interfaces;

namespace WebApplication1.Models;

public class Member : IEntity
{
    [BsonId]
    [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
    public string? Id { get; set; }
    
    [BsonElement("name")]
    public string Name { get; set; }
    
    [BsonElement("image")]
    public string Image { get; set; }
    
    [BsonElement("instruments")]
    public string Instruments { get; set; }
    
    [BsonElement("years active")]
    public string YearsActive { get; set; }
}
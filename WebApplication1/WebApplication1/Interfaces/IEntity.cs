using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WebApplication1.Interfaces;

public interface IEntity
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    string Id { get; set; }
}
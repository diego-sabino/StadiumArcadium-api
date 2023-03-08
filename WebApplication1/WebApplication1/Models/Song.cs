using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using WebApplication1.Interfaces;

namespace WebApplication1.Models
{
    public class Song : IEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
        
        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("albumId")]
        public string AlbumId { get; set; }

        [BsonElement("duration")]
        public int Duration { get; set; }

        [BsonElement("lyrics")]
        public string Lyrics { get; set; }

        [BsonElement("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }

        [BsonElement("genre")]
        public string Genre { get; set; }
    }
}
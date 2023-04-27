using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace MongoDBAPI.Models
{
    [BsonIgnoreExtraElements]
    public class Planet
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; } = String.Empty;

        [BsonElement("name")]
        public string Name { get; set; } = String.Empty;

        [BsonElement("orderFromSun")]
        public int OrderFromSun { get; set; }

        [BsonElement("mainAtmosphere")]
        public string[]? MainAtmosphere { get; set; }

        [BsonElement("gender")]
        public bool hasRings { get; set; } = false;



    }
}

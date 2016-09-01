using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoRepository.Entities
{
    /// <summary>
    /// Base class for all mongodb entities
    /// </summary>
    public class MongoEntity : IMongoEntity
    {
        [BsonElement("_id")]
        public ObjectId Id { get; set; }
    }
}

using MongoDB.Bson;

namespace MongoRepository.Entities
{
    public interface IMongoEntity
    {
        ObjectId Id { get; set; }
    }
}

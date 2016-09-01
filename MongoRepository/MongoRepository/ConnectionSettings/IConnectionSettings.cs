using MongoDB.Driver;

namespace MongoRepository.ConnectionSettings
{
    public interface IConnectionSettings
    {
        IMongoDatabase GetDatabase();
    }
}

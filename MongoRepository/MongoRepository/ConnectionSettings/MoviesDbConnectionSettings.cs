using MongoDB.Driver;
using System.Configuration;

namespace MongoRepository.ConnectionSettings
{
    /// <summary>
    /// Specifies settings for connecting to movies database.
    /// </summary>
    public class MoviesDbConnectionSettings : IConnectionSettings
    {
        public IMongoDatabase GetDatabase()
        {
            string connectionString = ConfigurationManager.AppSettings["MongoConnectionString"];
            string databaseName = ConfigurationManager.AppSettings["MongoDatabaseName"];
            IMongoClient client = new MongoClient(connectionString);
            return client.GetDatabase(databaseName);
        }
    }
}

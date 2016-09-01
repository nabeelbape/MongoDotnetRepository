using MongoDB.Driver;
using MongoRepository.ConnectionSettings;
using MongoRepository.Entities;

namespace MongoRepository
{
    /// <summary>
    /// Sample repository class demonstrating use of MongoGenericRepository.
    /// </summary>
    public class MoviesRepository : MongoGenericRepository<Movie>
    {
        public MoviesRepository()
            : base("movies")
        {
            // Injecting Movies db connection settings.
            base.ConnectionSettings = new MoviesDbConnectionSettings();
        }

        public override void Update(Movie document)
        {
            var filter = Builders<Movie>.Filter.Eq("_id", document.Id);
            var update = Builders<Movie>.Update
                .Set(s => s.Name, document.Name)
                .Set("director", document.Director);
            GetCollection().UpdateOne(filter, update);
        }
    }
}

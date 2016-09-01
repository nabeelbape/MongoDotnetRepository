using MongoDB.Bson;
using MongoDB.Driver;
using MongoRepository.ConnectionSettings;
using MongoRepository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository
{
    /// <summary>
    /// Generic repository class that provides functions to do basic operations on a mongodb collection.
    /// </summary>
    /// <typeparam name="T">Type which is a mongodb entity and should implement IMongoEntity interface.</typeparam>
    public abstract class MongoGenericRepository<T> where T : IMongoEntity
    {
        private readonly string _collectionName;
        private IConnectionSettings _connectionSettings;

        /// <summary>
        /// Specifies the settings to be used for connecting to the mongodb database.
        /// </summary>
        public IConnectionSettings ConnectionSettings
        {
            set
            {
                _connectionSettings = value;
            }
        }

        /// <summary>
        /// Assumes collection name as lowercase name of type T with a postfix 's'.
        /// </summary>
        public MongoGenericRepository()
        {
            _collectionName = typeof(T).Name.ToLower() + "s";
        }

        public MongoGenericRepository(string collectionName)
        {
            _collectionName = collectionName;
        }

        public IMongoCollection<T> GetCollection()
        {
            var database = _connectionSettings.GetDatabase();
            return database.GetCollection<T>(_collectionName);
        }

        public virtual List<T> GetAll()
        {
            return GetCollection().AsQueryable().ToList();
        }

        public virtual T GetById(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            return GetCollection().Find(filter).SingleOrDefault();
        }

        public virtual T GetById(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            return GetCollection().Find(filter).SingleOrDefault();
        }

        public virtual List<T> GetByProperty(string property, string value)
        {
            var filter = Builders<T>.Filter.Eq(property, value);
            return GetCollection().Find(filter).ToList();
        }

        public virtual void Insert(T document)
        {
            GetCollection()
                .WithWriteConcern(WriteConcern.Acknowledged)
                .InsertOne(document);
        }

        public virtual void InsertMany(List<T> documents)
        {
            GetCollection()
                .WithWriteConcern(WriteConcern.Acknowledged)
                .InsertMany(documents);
        }

        public virtual void Delete(string id)
        {
            var filter = Builders<T>.Filter.Eq("_id", ObjectId.Parse(id));
            GetCollection().DeleteOne(filter);
        }

        public virtual void Delete(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            GetCollection().DeleteOne(filter);
        }

        public abstract void Update(T document);
    }
}

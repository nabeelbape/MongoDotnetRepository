using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoRepository.Entities
{
    /// <summary>
    /// Sample entity class representing a document in a mongodb collection.
    /// </summary>
    [BsonIgnoreExtraElements]
    public class Movie : MongoEntity
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("director")]
        public string Director { get; set; }

        [BsonElement("release_dt")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime ReleaseDate { get; set; }

        [BsonElement("actors")]
        public List<string> Actors { get; set; }

        [BsonIgnoreIfNull]
        [BsonElement("awards")]
        public List<string> Awards { get; set; }

        [BsonIgnore]
        public string ExtraProperty { get; set; }
    }
}

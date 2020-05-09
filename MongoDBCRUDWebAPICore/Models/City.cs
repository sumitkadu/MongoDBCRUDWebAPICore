using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDBCRUDWebAPICore.Models
{   
        public class City
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string Id { get; set; }

            [BsonElement("Name")]
            public string CityName { get; set; }

            public int TotalCases { get; set; }

            public int Recovered { get; set; }

            public int Deaths { get; set; }
        }
    }

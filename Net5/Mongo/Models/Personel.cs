using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Models
{
    public class Personel
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Title { get; set; }
        public int Age { get; set; }

    }
}

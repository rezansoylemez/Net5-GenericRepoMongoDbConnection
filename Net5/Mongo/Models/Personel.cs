using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections;

namespace Mongo.Models
{
    public class Personel
    {
        [BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int PersonelDetailId { get; set; }
        public PersonelDetail PersonelDetail { get; set; }
        public int CompanyId { get; set; }
        public Company Company { get; set; }

    }
}

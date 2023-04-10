using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Mongo.Models
{
    public class Company
    {
        [BsonId]

        public int Id { get; set; }
        public string Name { get; set; }
        public int Count { get; set; }
        public string  Category { get; set; }
        public ICollection<Personel> Personels { get; set; }

    }
}

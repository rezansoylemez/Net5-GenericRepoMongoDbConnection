using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.Models
{
    public class PersonelDetail
    {
        [BsonId]
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int Age { get; set; }
        public string Title { get; set; }
        public string JobDescription { get; set; }
        public int PersonelId { get; set; }
        public Personel Personel { get; set; }
    }
}

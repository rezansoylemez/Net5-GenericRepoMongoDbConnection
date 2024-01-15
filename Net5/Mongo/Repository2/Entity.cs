using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Mongo.Repository2
{ 
    public class Entity<TIdType>
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)] // Use String representation for non-ObjectId Ids
        public TIdType Id { get; set; }

        [BsonElement("Code")] // Map to a field named "Code" in MongoDB
        public string? Code { get; set; }

        [BsonElement("Status")]
        public bool Status { get; set; }

        [BsonElement("IsDeleted")]
        public bool? IsDeleted { get; set; }

        [BsonElement("CreatedDate")]
        public DateTime CreatedDate { get; set; }

        [BsonElement("UpdatedDate")]
        public DateTime? UpdatedDate { get; set; }

        [BsonElement("DeletedDate")]
        public DateTime? DeletedDate { get; set; }

        public Entity()
        {
            // You may initialize default values or perform additional setup here
        }

        public Entity(TIdType id, string code)
        {
            Id = id;
            Code = code;
        }

        public Entity(TIdType id)
        {
            Id = id;
        }
    }
}

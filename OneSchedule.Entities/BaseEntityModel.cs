using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OneSchedule.Entities
{
    public abstract class BaseEntityModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}

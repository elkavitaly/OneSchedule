using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace OneSchedule.Entities.Abstraction
{
    public abstract class EntityModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
    }
}

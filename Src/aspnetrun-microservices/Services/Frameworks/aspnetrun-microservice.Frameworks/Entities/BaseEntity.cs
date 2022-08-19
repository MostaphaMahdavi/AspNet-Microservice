using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace aspnetrun_microservice.Frameworks.Entities
{
    public class BaseEntity<T>
    {
        public T Id  { get; set; }
        public DateTime CreatedDate { get; set; }
        public BaseEntity()
        {
            CreatedDate = DateTime.UtcNow;
        }

     }

    public class BaseEntity: BaseEntity<Guid>
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
        }
    }

    public class BaseMongoEntity<T>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public T Id { get; set; }

    }

    public class BaseMongoEntity:BaseMongoEntity<string>
    {

    }
}


using MongoDB.Bson.Serialization.Attributes;

namespace MatkesPuslapis.Core
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public int Role { get; set; }

    }
}

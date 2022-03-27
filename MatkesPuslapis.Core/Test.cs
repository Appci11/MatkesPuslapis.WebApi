//Bet ko bandymams/testavimui. Uzbaigtai programai nereikalinga

using MongoDB.Bson.Serialization.Attributes;

namespace MatkesPuslapis.Core
{
    
    public class Test
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }
}

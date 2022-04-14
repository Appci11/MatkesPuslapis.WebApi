using MongoDB.Bson.Serialization.Attributes;

namespace MatkesPuslapis.Core
{
    
    public class Test
    {
        public Test()
        {
        }

        public Test(string name)
        {
            Name = name;
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
    }
}

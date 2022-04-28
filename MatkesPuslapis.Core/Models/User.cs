using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace MatkesPuslapis.Core
{
    public class User
    {
        public User()
        {
            SolvedTopics = new List<string>();
        }

        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
        public string Username { get; set; }
        public string EMail { get; set; }
        public string Password { get; set; }
        public List<string> SolvedTopics { get; set; }
    }
}

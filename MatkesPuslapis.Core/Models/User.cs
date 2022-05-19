using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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
        public bool IsAdmin { get; set; } = false;

        [JsonIgnore]
        public string Password { get; set; }
        public List<string> SolvedTopics { get; set; }
    }
}

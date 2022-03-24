using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core
{
    public class DbClient : IDbClient
    {
        private readonly IMongoCollection<User> _users;
        public DbClient(IOptions<MatkesPuslapisDbConfig> matkesPuslapisDbConfig)
        {
            var client = new MongoClient(matkesPuslapisDbConfig.Value.Connection_String);
            var database = client.GetDatabase(matkesPuslapisDbConfig.Value.Database_Name);
            _users = database.GetCollection<User>(matkesPuslapisDbConfig.Value.Users_Collection_Name);
        }
        public IMongoCollection<User> GetUsersCollection() => _users;
    }
}

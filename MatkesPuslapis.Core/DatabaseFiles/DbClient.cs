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
        private readonly IMongoCollection<Test> _tests;
        private readonly IMongoCollection<Question> _questions;
        public DbClient(IOptions<MatkesPuslapisDbConfig> matkesPuslapisDbConfig)
        {
            var client = new MongoClient(matkesPuslapisDbConfig.Value.Connection_String);
            var database = client.GetDatabase(matkesPuslapisDbConfig.Value.Database_Name);
            _users = database.GetCollection<User>(matkesPuslapisDbConfig.Value.Users_Collection_Name);
            _tests = database.GetCollection<Test>(matkesPuslapisDbConfig.Value.Tests_Collection_Name);
            _questions = database.GetCollection<Question>(matkesPuslapisDbConfig.Value.Questions_Collection_Name);

        }
        public IMongoCollection<User> GetUsersCollection() => _users;
        public IMongoCollection<Test> GetTestsCollection() => _tests;
        public IMongoCollection<Question> GetQuestionsCollection() => _questions;
    }
}

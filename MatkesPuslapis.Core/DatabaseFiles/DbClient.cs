using MatkesPuslapis.Core.Models;
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
        private readonly IMongoCollection<Topic> _stories;
        private readonly IMongoCollection<Topic> _topics;
        public DbClient(IOptions<MatkesPuslapisDbConfig> matkesPuslapisDbConfig)
        {
            var client = new MongoClient("mongodb+srv://MatkesPuslapis:PuslapisMatkes@cluster0.fmm2x.mongodb.net/MatkesPuslapisDb?retryWrites=true&w=majority");
            var database = client.GetDatabase(matkesPuslapisDbConfig.Value.Database_Name);
            _users = database.GetCollection<User>(matkesPuslapisDbConfig.Value.Users_Collection_Name);
            _tests = database.GetCollection<Test>(matkesPuslapisDbConfig.Value.Tests_Collection_Name);
            _questions = database.GetCollection<Question>(matkesPuslapisDbConfig.Value.Questions_Collection_Name);
            _stories = database.GetCollection<Topic>(matkesPuslapisDbConfig.Value.Stories_Collection_Name);
            _topics = database.GetCollection<Topic>(matkesPuslapisDbConfig.Value.Topics_Collection_Name);

        }
        public IMongoCollection<User> GetUsersCollection() => _users;
        public IMongoCollection<Test> GetTestsCollection() => _tests;
        public IMongoCollection<Question> GetQuestionsCollection() => _questions;
        public IMongoCollection<Topic> GetStoriesCollection() => _stories;  //refractoring fail
        public IMongoCollection<Topic> GetTopicsCollection() => _topics;
    }
}

//Bet ko bandymams/testavimui. Uzbaigtai programai nereikalinga

using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MatkesPuslapis.Core
{
    public class TestServices : ITestServices
    {
        private readonly IMongoCollection<User> _tests;
        public TestServices(IDbClient dbClient)
        {
            _tests = dbClient.GetUsersCollection();
        }

        public List<User> GetTests() => _tests.Find(test => true).ToList();
    }
}

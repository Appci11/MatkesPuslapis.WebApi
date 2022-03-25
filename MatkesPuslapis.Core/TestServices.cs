using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MatkesPuslapis.Core
{
    public class TestServices : ITestServices
    {
        private readonly IMongoCollection<Test> _tests;
        public TestServices(IDbClient dbClient)
        {
            _tests = dbClient.GetTestsCollection();
        }

        public List<Test> GetTests() => _tests.Find(test => true).ToList();
    }
}

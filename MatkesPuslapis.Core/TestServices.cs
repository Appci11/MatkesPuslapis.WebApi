//Bet ko bandymams/testavimui. Uzbaigtai programai nereikalinga

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

        public Test AddTest(Test test)
        {
            _tests.InsertOne(test);
            return test;
        }

        public List<Test> GetTests() => _tests.Find(test => true).ToList();

    }
}

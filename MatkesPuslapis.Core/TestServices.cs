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

        public void DeleteTest(string id)
        {
            _tests.DeleteOne(test => test.Id == id);
        }

        public Test GetTest(string id) => _tests.Find(test => test.Id == id).First();

        public List<Test> GetTests() => _tests.Find(test => true).ToList();

        public bool NameExists(string name)
        {
            bool exists = true;
            try
            {
                _tests.Find(user => user.Name == name).First();
            }
            catch (Exception ex)
            {
                exists = false;
            }
            return exists;
        }

        public Test UpdateTest(Test test)
        {
            GetTest(test.Id);
            _tests.ReplaceOne(u => u.Id == test.Id, test);
            return test;
        }
    }
}

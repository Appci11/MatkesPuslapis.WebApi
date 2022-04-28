using MatkesPuslapis.Core.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core
{
    public interface IDbClient
    {
        IMongoCollection<User> GetUsersCollection();
        IMongoCollection<Test> GetTestsCollection();
        IMongoCollection<Question> GetQuestionsCollection();
        IMongoCollection<Topic> GetStoriesCollection();
    }
}

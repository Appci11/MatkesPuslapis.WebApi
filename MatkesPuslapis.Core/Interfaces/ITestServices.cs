//Bet ko bandymams/testavimui. Uzbaigtai programai nereikalinga

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Praktiskai nenaudojama, lieka, nes kitai lentelei atsiradus, uzteks pervadint

namespace MatkesPuslapis.Core
{
    public interface ITestServices
    {
        List<Test> GetTests();
        Test AddTest(Test test);
        Test GetTest(string id);
        Test GetTestByName(string id);
        void DeleteTest(string id);
        Test UpdateTest(Test test);
        bool NameExists(string name);
    }
}

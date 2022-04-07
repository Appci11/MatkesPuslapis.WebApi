//Bet ko bandymams/testavimui. Uzbaigtai programai nereikalinga

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core
{
    public interface ITestServices
    {
        List<Test> GetTests();
        Test AddTest(Test test);
    }
}

using MatkesPuslapis.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core
{
    public interface IUserServices
    {
        List<User> GetUsers();
        User GetUser(string id);
        User GetUserByUsername(string username);
        User AddUser(User user);
        void DeleteUser(string id);
        User UpdateUser(User user);
        bool UsernameExists(string username);
        bool EmailExists(string email);
        //User AddSolvedTopic(UserTopic ut);
        User AddSolvedTopic(UserTopic userTopic);
        User RemoveSolvedTopic(UserTopic userTopic);





        //string Test();
        //User AddUser(string username, string email, string password);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(string email, string password);
        User AddUser(string username, string email, string password);
        bool UsernameExists(string username);
        bool EmailExists(string email);
    }
}

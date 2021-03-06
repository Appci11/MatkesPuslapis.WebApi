using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace MatkesPuslapis.Core
{
    public class UserRegisterCredentials
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
       
        [JsonIgnore]
        public bool IsAdmin { get; set; } = false;
    }
}

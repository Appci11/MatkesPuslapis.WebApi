using System;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using MongoDB.Driver;

namespace MatkesPuslapis.Core
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {
        private readonly IMongoCollection<User> _users;

        private readonly string key;

        public JwtAuthenticationManager(string key)
        {
            this.key = key;
            //reiketu sekancias 3 eilutes per startup.cs ir pakeista konstruktoriu paleidinet - nemoku.
            var client = new MongoClient("mongodb+srv://MatkesPuslapis:PuslapisMatkes@cluster0.fmm2x.mongodb.net/MatkesPuslapisDb?retryWrites=true&w=majority");
            var database = client.GetDatabase("MatkesPuslapisDb");
            _users = database.GetCollection<User>("Users");
        }
        public string Authenticate(string email, string password)
        {
            User user;

            try
            {
                user = _users.Find(user => user.EMail == email && user.Password == password).First();
            }
            catch (Exception ex)
            {
                return null;
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials =
                new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public User GetUser(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var idk = tokenHandler.ReadJwtToken(token.Split(' ')[1]);
            var wtf = idk.Claims.First().Value;
            User user = _users.Find(user => user.Id == wtf).First();
            return user;
        }

        public User AddUser(string username, string email, string password)
        {
            User user = new User();
            user.Username = username;
            user.EMail = email;
            user.Password = password;
            user.IsAdmin = false;
            _users.InsertOne(user);
            return user;
        }

        public bool UsernameExists(string username)
        {
            bool exists = true;
            try
            {
                _users.Find(user => user.Username == username).First();
            }
            catch (Exception ex)
            {
                exists = false;
            }
            return exists;
        }

        public bool EmailExists(string email)
        {
            bool exists = true;
            try
            {
                _users.Find(user => user.EMail == email).First();
            }
            catch (Exception ex)
            {
                exists = false;
            }
            return exists;
        }
    }
}

using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;

namespace MatkesPuslapis.Core
{
    public class UserServices : IUserServices
    {
        private readonly IMongoCollection<User> _users;
        public UserServices(IDbClient dbClient)
        {
            _users = dbClient.GetUsersCollection();
        }
        /// <summary>
        /// Prideda "User" objekto irasa i "Users" lentele duomenu bazeje
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public User AddUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }
        /// <summary>
        /// Prideda "User" objekto irasa i "Users" lentele duomenu bazeje
        /// </summary>
        /// <param name="username"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User AddUser(string username, string email, string password)
        {
            User user = new User();
            user.Name = username;
            user.EMail = email;
            user.Password = password;
            _users.InsertOne(user);
            return user;
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(user => user.Id == id);
        }

        public User GetUser(string id) => _users.Find(user => user.Id == id).First();
        
        //Hardcode'inta versija
        //public List<User> GetUsers()
        //{
        //    return new List<User>
        //    {
        //        new User
        //        {
        //            Name = "Test",
        //            EMail = "Pastas@Post.com"
        //        }
        //    };
        //}

        public List<User> GetUsers() => _users.Find(user => true).ToList();

        public User UpdateUser(User user)
        {
            GetUser(user.Id);
            _users.ReplaceOne(u => u.Id == user.Id, user);
            return user;
        }

        public bool UsernameExists(string username)
        {
            bool exists = true;
            try
            {
                _users.Find(user => user.Name == username).First();
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
        public string Test()
        {
            try
            {
                _users.Find(user => user.EMail == "aaa" && user.Password == "aaa").First();
            }
            catch (Exception ex)
            {
                return "Nera";
            }
            return "Yra";
        }
    }
}

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

        public User AddUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public User AddUser2(string username, string email, string password)
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


    }
}

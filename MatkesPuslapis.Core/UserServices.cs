using MatkesPuslapis.Core.Models;
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

        public User AddUser(User user)
        {
            _users.InsertOne(user);
            return user;
        }

        public List<User> GetUsers() => _users.Find(user => true).ToList();

        public User GetUser(string id) => _users.Find(user => user.Id == id).First();

        public User GetUserByUsername(string username) => _users.Find(user => user.Username == username).First();

        public User UpdateUser(User user)
        {
            GetUser(user.Id);
            _users.ReplaceOne(u => u.Id == user.Id, user);

            return user;
        }

        public void DeleteUser(string id)
        {
            _users.DeleteOne(user => user.Id == id);
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

        public User AddSolvedTopic(UserTopic userTopic)
        {
            {
                User user = GetUser(userTopic.UserId);
                user.SolvedTopics.Add(userTopic.TopicId);
                _users.ReplaceOne(u => u.Id == user.Id, user);

                return user;
            }
        }

        public User RemoveSolvedTopic(UserTopic userTopic)
        {
            {
                User user = GetUser(userTopic.UserId);
                user.SolvedTopics.Remove(userTopic.TopicId);
                _users.ReplaceOne(u => u.Id == user.Id, user);

                return user;
            }
        }

        //public User UpdateUser(User user)
        //{
        //    GetUser(user.Id);
        //    _users.ReplaceOne(u => u.Id == user.Id, user);

        //    return user;
        //}
    }
}


////irgi nenaudojama, bet tingiu trint
//public string Test()
//{
//    throw new NotImplementedException();
//}


////lyg ir nebereikia
//public User AddUser(string username, string email, string password)
//{
//    throw new NotImplementedException();
//}



////Hardcode'inta versija
////public List<User> GetUsers()
////{
////    return new List<User>
////    {
////        new User
////        {
////            Title = "Test",
////            EMail = "Pastas@Post.com"
////        }
////    };
////}





//public bool UsernameExists(string username)
//{
//    bool exists = true;
//    try
//    {
//        _users.Find(user => user.Username == username).First();
//    }
//    catch (Exception ex)
//    {
//        exists = false;
//    }
//    return exists;
//}

//public bool EmailExists(string email)
//{
//    bool exists = true;
//    try
//    {
//        _users.Find(user => user.EMail == email).First();
//    }
//    catch (Exception ex)
//    {
//        exists = false;
//    }
//    return exists;
//}
//public string Test()
//{
//    try
//    {
//        _users.Find(user => user.EMail == "aaa" && user.Password == "aaa").First();
//    }
//    catch (Exception ex)
//    {
//        return "Nera";
//    }
//    return "Yra";
//}


//public User AddUser(string username, string email, string password)
//{
//    User user = new User();
//    user.Username = username;
//    user.EMail = email;
//    user.Password = password;
//    _users.InsertOne(user);
//    return user;
//}
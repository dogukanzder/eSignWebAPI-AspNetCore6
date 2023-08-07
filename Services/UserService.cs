//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using eSignAPI.Interfaces;
using eSignAPI.Models;
using MongoDB.Driver;

namespace eSignAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IMongoCollection<User> _users;

        public UserService(IUsersLoginDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _users = database.GetCollection<User>(settings.UserCollectionName);
        }

        public List<User> GetUsers()
        {
            return _users.Find(user => true).ToList();
        }

        public User CreateUser(User user)
        {
            if (_users.Find(userx => userx.Email == user.Email).Count() == 0 && _users.Find(userx => userx.Phone == user.Phone).Count() == 0)
            {
                var textBytes = System.Text.Encoding.UTF8.GetBytes(user.Password);
                user.Password = System.Convert.ToBase64String(textBytes);
                _users.InsertOne(user);
            }
            else
            {
                user.Id = "null";
            }
            return user;
        }

        public bool DeleteUser(string id)
        {
            _users.DeleteOne(user => user.Id == id);
            return true;
        }

        public User GetUserById(string id)
        {
            return _users.Find(user => user.Id == id).FirstOrDefault();
        }


        public User GetUserByEmail(string email)
        {
            return _users.Find(user => user.Email == email).FirstOrDefault();
        }


        public bool UpdateUser(string id, User user)
        {
            _users.ReplaceOne(user => user.Id == id, user);
            return true;
        }
    }
}

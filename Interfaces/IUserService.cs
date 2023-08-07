//  ╬═════════╬ ***
//  ║░█░█░█░█░║ /dogukanzder
//  ║█░█░█░█░█║ ©2023
//  ╬═════════╬ ***

using eSignAPI.Models;

namespace eSignAPI.Interfaces
{
    public interface IUserService
    {
        List<User> GetUsers();
        User GetUserById(string id);
        User GetUserByEmail(string email);
        User CreateUser(User user);
        bool UpdateUser(string id, User user);
        bool DeleteUser(string id);
    }
}

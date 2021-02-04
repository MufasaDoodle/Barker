using Barker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barker.Data.UserService
{
    public interface IUserService
    {
        Task<User> CreateUserAsync(User user);
        Task<User> GetUserAsync(string email);
        Task<User> GetUserAsync(int id);
        Task<User> UpdateUserAsync(User user);
        Task DeleteUserAsync(int userID);
    }
}

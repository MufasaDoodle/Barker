using Barker_API.Models;
using Barker_API.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barker_API.Data
{
    public class UserService : IUserService
    {
        IUserRepo repo;

        public UserService()
        {
            repo = new UserRepo();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            return await repo.CreateUserAsync(user);
        }

        public async Task DeleteUserAsync(int userID)
        {
            await repo.DeleteUserAsync(userID);
        }

        public async Task<User> GetUserAsync(string email)
        {
            return await repo.GetUserAsync(email);
        }

        public async Task<User> GetUserAsync(int id)
        {
            return await repo.GetUserAsync(id);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            return await repo.UpdateUserAsync(user);
        }
    }
}

using Barker_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barker_API.Persistence
{
    public class UserRepo : IUserRepo
    {
        private DatabaseContext context;

        public UserRepo()
        {
            context = new DatabaseContext();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task DeleteUserAsync(int userID)
        {
            User toRemove = context.Users.First(user => user.UserID == userID);

            if(toRemove == null)
            {
                return;
            }

            context.Remove(toRemove);
            await context.SaveChangesAsync();
        }

        public async Task<User> GetUserAsync(string email)
        {
            User returnUser = context.Users.First(user => user.Email == email);
            if(returnUser == null)
            {
                return null;
            }

            return returnUser;
        }

        public async Task<User> GetUserAsync(int id)
        {
            User returnUser = context.Users.First(user => user.UserID == id);
            if (returnUser == null)
            {
                return null;
            }

            return returnUser;
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            context.Update(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}

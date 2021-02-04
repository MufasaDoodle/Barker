using Barker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Barker.Data.UserService
{
    public class UserService : IUserService
    {
        HttpClient client;
        string uri = "https://localhost:44374/Users";

        public UserService()
        {
            client = new HttpClient();
        }

        public async Task<User> CreateUserAsync(User user)
        {
            string userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            var returnContent = await client.PostAsync(uri, content);
            string returnJson = await returnContent.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(returnJson);
        }

        public async Task DeleteUserAsync(int userID)
        {            
            await client.DeleteAsync($"{uri}/{userID}");
        }

        public async Task<User> GetUserAsync(string email)
        {
            string message = await client.GetStringAsync($"{uri}/{email}");
            return JsonSerializer.Deserialize<User>(message);
        }

        public async Task<User> GetUserAsync(int id)
        {
            string message = await client.GetStringAsync($"{uri}/{id}");
            return JsonSerializer.Deserialize<User>(message);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            string userAsJson = JsonSerializer.Serialize(user);
            HttpContent content = new StringContent(userAsJson,
                Encoding.UTF8,
                "application/json");
            var returnContent = await client.PatchAsync(uri, content);
            string returnJson = await returnContent.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<User>(returnJson);
        }
    }
}

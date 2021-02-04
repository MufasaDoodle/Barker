using Barker.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Barker.Data.BarkService
{
    public class BarkService : IBarkService
    {
        HttpClient client;
        string uri = "https://localhost:44374/Barks";

        public BarkService()
        {
            client = new HttpClient();
        }

        public async Task<Bark> CreateBarkAsync(Bark bark)
        {
            string barkAsJson = JsonSerializer.Serialize(bark);
            HttpContent content = new StringContent(barkAsJson,
                Encoding.UTF8,
                "application/json");
            var returnContent = await client.PostAsync(uri, content);
            string returnJson = await returnContent.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Bark>(returnJson);
        }

        public async Task DeleteBarkAsync(int barkID)
        {
            await client.DeleteAsync($"{uri}/{barkID}");
        }

        public async Task<Bark> GetBarkAsync(int barkID)
        {
            string message = await client.GetStringAsync($"{uri}/{barkID}");
            return JsonSerializer.Deserialize<Bark>(message);
        }

        public async Task<List<Bark>> GetBarksByUserAsync(int userID)
        {
            string message = await client.GetStringAsync($"{uri}/byUser/{userID}");
            return JsonSerializer.Deserialize<List<Bark>>(message);
        }

        public async Task<Bark> UpdateBarkAsync(Bark bark)
        {
            string barkAsJson = JsonSerializer.Serialize(bark);
            HttpContent content = new StringContent(barkAsJson,
                Encoding.UTF8,
                "application/json");
            var returnContent = await client.PatchAsync(uri, content);
            string returnJson = await returnContent.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<Bark>(returnJson);
        }
    }
}

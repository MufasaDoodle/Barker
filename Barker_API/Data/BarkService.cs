using Barker_API.Models;
using Barker_API.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barker_API.Data
{
    public class BarkService : IBarkService
    {
        IBarkRepo repo;

        public BarkService()
        {
            repo = new BarkRepo();
        }

        public async Task<Bark> CreateBarkAsync(Bark bark)
        {
            return await repo.CreateBarkAsync(bark);
        }

        public async Task DeleteBarkAsync(int barkID)
        {
            await repo.DeleteBarkAsync(barkID);
        }

        public async Task<Bark> GetBarkAsync(int barkID)
        {
            return await repo.GetBarkAsync(barkID);
        }

        public async Task<List<Bark>> GetBarksByUserAsync(int userID)
        {
            return await repo.GetBarksByUserAsync(userID);
        }

        public async Task<Bark> UpdateBarkAsync(Bark bark)
        {
            return await repo.UpdateBarkAsync(bark);
        }
    }
}

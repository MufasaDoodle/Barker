using Barker_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barker_API.Persistence
{
    public class BarkRepo : IBarkRepo
    {
        private DatabaseContext context;

        public BarkRepo()
        {
            context = new DatabaseContext();
        }

        public async Task<Bark> CreateBarkAsync(Bark bark)
        {
            await context.Barks.AddAsync(bark);
            await context.SaveChangesAsync();
            return bark;
        }

        public async Task DeleteBarkAsync(int barkID)
        {
            Bark toRemove = context.Barks.First(bark => bark.BarkID == barkID);

            if (toRemove == null)
            {
                return;
            }

            context.Remove(toRemove);
            await context.SaveChangesAsync();
        }

        public async Task<Bark> GetBarkAsync(int barkID)
        {
            Bark returnBark = context.Barks.First(bark => bark.BarkID == barkID);
            if (returnBark == null)
            {
                return null;
            }

            return returnBark;
        }

        public async Task<List<Bark>> GetBarksByUserAsync(int userID)
        {
            IEnumerable<Bark> temp = context.Barks.Where(bark => bark.UserID == userID);
            List<Bark> returnBarks = temp.ToList();
            if (returnBarks == null)
            {
                return null;
            }

            return returnBarks;
        }

        public async Task<Bark> UpdateBarkAsync(Bark bark)
        {
            context.Update(bark);
            await context.SaveChangesAsync();
            return bark;
        }
    }
}

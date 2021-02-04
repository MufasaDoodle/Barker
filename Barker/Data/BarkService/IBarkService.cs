using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Barker.Models;

namespace Barker.Data.BarkService
{
    interface IBarkService
    {
        Task<Bark> CreateBarkAsync(Bark bark);
        Task<Bark> GetBarkAsync(int barkID);
        Task<List<Bark>> GetBarksByUserAsync(int userID);
        Task<Bark> UpdateBarkAsync(Bark bark);
        Task DeleteBarkAsync(int barkID);
    }
}

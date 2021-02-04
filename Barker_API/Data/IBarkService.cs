using Barker_API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Barker_API.Data
{
    public interface IBarkService
    {
        Task<Bark> CreateBarkAsync(Bark bark);
        Task<Bark> GetBarkAsync(int barkID);
        Task<List<Bark>> GetBarksByUserAsync(int userID);
        Task<Bark> UpdateBarkAsync(Bark bark);
        Task DeleteBarkAsync(int barkID);
    }
}

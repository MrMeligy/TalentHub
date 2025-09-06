using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Contracts
{
    public interface IPlayerMatchService
    {
        Task<IReadOnlyList<PlayerMatch>> GetAllAsync();
        Task<PlayerMatch?> GetByIdAsync(Guid id);
        Task<PlayerMatch> CreateAsync(PlayerMatch playerMatch);
        Task<bool> UpdateAsync(Guid id, PlayerMatch updated);
        Task<bool> DeleteAsync(Guid id);
    }
}

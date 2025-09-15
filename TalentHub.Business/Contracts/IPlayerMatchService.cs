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
        Task<IReadOnlyList<PlayerMatch>> GetByMatchAsync(Guid matchId);
        Task<IReadOnlyList<PlayerMatch>> GetByPlayerAsync(Guid playerId);
        Task<PlayerMatch?> GetByIdAsync(Guid id);
        Task<PlayerMatch> CreateAsync(PlayerMatch playerMatch);
        Task<bool> DeleteAsync(Guid id);
    }
}

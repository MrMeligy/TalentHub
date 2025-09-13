using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TalentHub.Business.Dtos.PlayerDto;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Abstraction
{
    public interface IPlayerRepository : IRepository<Player>
    {
        Task<IReadOnlyList<PlayerReadDto>> GetAllPlayersAsync(int skip, int pageSize);
        Task<IReadOnlyList<PlayerReadDto>> GetPlayersByTeamAsync(Guid teamId);
        Task<IReadOnlyList<PlayerReadDto>> GetPlayersByAcademyAsync(Guid academyId, int skip, int pageSize);
        Task<IReadOnlyList<PlayerReadDto>> GetPlayersByMatchAsync(Guid matchId);
        Task<PlayerReadDto?> GetPlayerByIdAsync(Guid playerId);

    }
}

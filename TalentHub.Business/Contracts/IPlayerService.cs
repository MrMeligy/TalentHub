using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Dtos;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Contracts
{
    public interface IPlayerService
    {
        Task<IReadOnlyList<PlayerDto>> GetAllPlayersAsync(int skip,int pageSize);
        Task<IReadOnlyList<PlayerDto>> GetPlayersByTeamAsync(Guid teamId);
        Task<IReadOnlyList<PlayerDto>> GetPlayersByAcademyAsync(Guid academyId,int skip,int pageSize);
        Task<IReadOnlyList<PlayerDto>> GetPlayersByMatchAsync(Guid matchId);
        Task<PlayerDto?> GetPlayerByIdAsync(Guid playerId);
        Task<Player> CreatePlayerAsync(Player player);
        Task<bool> UpdatePlayerAsync(Guid id,Player player);
        Task<bool> DeletePlayerAsync(Guid id);



    }
}

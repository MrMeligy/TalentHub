using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using TalentHub.Business.Contracts;
using static TalentHub.Business.Dtos.PlayerDto;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly IUnitOfWork _uow;

        public PlayerService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<Player> CreatePlayerAsync(Player player)
        {
                await _uow.Players.AddAsync(player);
                await _uow.SaveChangesAsync();
                return player;
        }

        public async Task<bool> DeletePlayerAsync(Guid id)
        {
            var existing = await _uow.Players.GetByIdAsync(id);
            if (existing is null) return false;
            _uow.Players.Remove(existing);
            await _uow.SaveChangesAsync();
            return true;
        }

        public Task<IReadOnlyList<PlayerReadDto>> GetAllPlayersAsync(int skip, int pageSize)=>_uow.Players.GetAllPlayersAsync(skip, pageSize);

        public Task<PlayerReadDto?> GetPlayerByIdAsync(Guid playerId)=>_uow.Players.GetPlayerByIdAsync(playerId);

        public Task<IReadOnlyList<PlayerReadDto>> GetPlayersByAcademyAsync(Guid academyId, int skip, int pageSize) => _uow.Players.GetPlayersByAcademyAsync(academyId, skip, pageSize);

        public Task<IReadOnlyList<PlayerReadDto>> GetPlayersByMatchAsync(Guid matchId) => _uow.Players.GetPlayersByMatchAsync(matchId);

        public Task<IReadOnlyList<PlayerReadDto>> GetPlayersByTeamAsync(Guid teamId) => _uow.Players.GetPlayersByTeamAsync(teamId);

        public async Task<bool> UpdatePlayerAsync(Guid id, Player player)
        {
            var existing = await _uow.Players.GetByIdAsync(id);
            if (existing is null) return false;
            existing.AcademyTeamId = player.AcademyTeamId;
            existing.Image = player.Image;
            existing.Name = player.Name;
            existing.Nationality = player.Nationality;
            existing.Position = player.Position;
            existing.Weight = player.Weight;
            existing.Height = player.Height;
            existing.ShirtNumber = player.ShirtNumber;
            existing.Rating = player.Rating;
            existing.DOB = player.DOB;
            existing.TotalSaves = player.TotalSaves;
            existing.TotalGoals = player.TotalGoals;
            existing.TotalAssists = player.TotalAssists;
            existing.AcademyTeamId = player.AcademyTeamId;
            existing.FavouriteFoot = player.FavouriteFoot; 
            existing.TotalInterceptions = player.TotalInterceptions;
            existing.TotalMatches = player.TotalMatches;
            existing.TotalMinutes  = player.TotalMinutes;
            existing.TotalTackles = player.TotalTackles;
            existing.SuccessTackles = player.SuccessTackles;
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}

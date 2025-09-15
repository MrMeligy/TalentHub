using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using TalentHub.Business.Contracts;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Services
{
    public class PlayerMatchService : IPlayerMatchService
    {
        private readonly IUnitOfWork _uow;
        public PlayerMatchService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<PlayerMatch> CreateAsync(PlayerMatch playerMatch)
        {
            await _uow.PlayerMatches.AddAsync(playerMatch);
            var player = await _uow.Players.GetByIdAsync(playerMatch.PlayerId);
            if (player != null)
            {
                player.Rating = ((player.Rating * player.TotalMatches) + playerMatch.Rating) / (player.TotalMatches + 1);
                player.TotalMatches += 1;
                player.TotalMinutes += playerMatch.Minutes;
                player.SuccessTackles += playerMatch.SuccessTackles;
                player.TotalTackles += playerMatch.Tackles;
                player.TotalGoals += playerMatch.Goals;
                player.TotalAssists += playerMatch.Assists;
                player.TotalSaves += playerMatch.Saves;
                player.TotalInterceptions += playerMatch.Interceptions;
            _uow.Players.Update(player);
            }
            await _uow.SaveChangesAsync();
            return playerMatch;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _uow.PlayerMatches.GetByIdAsync(id);
            if (existing is null) return false;
            var player = await _uow.Players.GetByIdAsync(existing.PlayerId);
            if (player != null)
            {
                if (player.TotalMatches > 1)
                {
                    player.Rating = (((player.Rating * player.TotalMatches) - existing.Rating)
                        / (player.TotalMatches - 1));
                }
                else
                {
                    player.Rating = 0;
                }
                player.TotalMatches -= 1;
                player.TotalMinutes -= existing.Minutes;
                player.SuccessTackles -= existing.SuccessTackles;
                player.TotalTackles -= existing.Tackles;
                player.TotalGoals -= existing.Goals;
                player.TotalAssists -= existing.Assists;
                player.TotalSaves -= existing.Saves;
                player.TotalInterceptions -= existing.Interceptions;
                _uow.Players.Update(player);
            }
            _uow.PlayerMatches.Remove(existing);
            await _uow.SaveChangesAsync();
            return true;
        }

        public async Task<PlayerMatch?> GetByIdAsync(Guid id)=> await _uow.PlayerMatches.GetByIdAsync(id);

        public async Task<IReadOnlyList<PlayerMatch>> GetByMatchAsync(Guid matchId) => await _uow.PlayerMatches.GetByMatch(matchId);


        public async Task<IReadOnlyList<PlayerMatch>> GetByPlayerAsync(Guid playerId) => await _uow.PlayerMatches.GetByPlayer(playerId);

        
    }
}

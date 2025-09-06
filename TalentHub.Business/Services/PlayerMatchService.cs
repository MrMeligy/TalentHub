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
            await _uow.SaveChangesAsync();
            return playerMatch;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _uow.PlayerMatches.GetByIdAsync(id);
            if (existing is null) return false;
            _uow.PlayerMatches.Remove(existing);
            await _uow.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyList<PlayerMatch>> GetAllAsync()=> await _uow.PlayerMatches.GetAllAsync();
        public async Task<PlayerMatch?> GetByIdAsync(Guid id)=> await _uow.PlayerMatches.GetByIdAsync(id);

        public async Task<bool> UpdateAsync(Guid id, PlayerMatch updated)
        {
            var existing = await _uow.PlayerMatches.GetByIdAsync(id);
            if (existing is null) return false;
            existing.Assists = updated.Assists;
            existing.Rating = updated.Rating;
            existing.Interceptions = updated.Interceptions;
            existing.Saves = updated.Saves;
            existing.Goals = updated.Goals;
            existing.SuccessTackles = updated.SuccessTackles;
            existing.Tackles = updated.Tackles;
            existing.Minutes = updated.Minutes;
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}

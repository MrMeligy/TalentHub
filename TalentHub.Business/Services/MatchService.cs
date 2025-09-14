using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using TalentHub.Business.Contracts;
using static TalentHub.Business.Dtos.MatchDto;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Services
{
    public class MatchService : IMatchService
    {
        private readonly IUnitOfWork _uow;
        public MatchService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<Match> CreateAsync(Match match)
        {
            await _uow.Matches.AddAsync(match);
            await _uow.SaveChangesAsync();
            return match;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _uow.Matches.GetByIdAsync(id);
            if (existing is null) return false;
            _uow.Matches.Remove(existing);
            await _uow.SaveChangesAsync();
            return true;
        }

        public Task<IReadOnlyList<MatchReadDto>> GetAllAsync() => _uow.Matches.GetAllWithAcademyNamesAsync();

        public Task<MatchReadDto?> GetByIdAsync(Guid id) => _uow.Matches.GetMatchByIdAsync(id);

        public async Task<bool> UpdateAsync(Guid id, Match updated)
        {
            var existing = await _uow.Matches.GetByIdAsync(id);
            if (existing is null) return false;
            existing.Kickoff = updated.Kickoff;
            existing.Venue = updated.Venue;
            existing.AwayScore = updated.AwayScore;
            existing.HomeScore = updated.HomeScore;
            await _uow.SaveChangesAsync();
            return true;
        }

    }
}

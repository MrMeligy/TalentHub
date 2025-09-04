using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;
using TalentHub.Data.Dtos;

namespace TalentHub.Data.Repositories
{
    public class MatchRepository : Repository<Match>,IMatchRepository
    {
        private readonly ApplicationDbContext _ctx;
        public MatchRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<IReadOnlyList<MatchDto>> GetAllWithAcademyNamesAsync()
        {
            
            return await _ctx.Matches
        .Include(m => m.HomeTeam)
            .ThenInclude(ht => ht.Academy)
        .Include(m => m.AwayTeam)
            .ThenInclude(at => at.Academy)
        .Select(m => new MatchDto
        {
            Id = m.Id,
            KickOff = m.Kickoff,

            HomeId = m.HomeId,
            HomeName = m.HomeTeam.Academy.Name,
            HomeImage = m.HomeTeam.Academy.Image,
            HomeAgeGroup = m.HomeTeam.AgeGroup,
            HomeScore = m.HomeScore,

            AwayId = m.AwayId,
            AwayName = m.AwayTeam.Academy.Name,
            AwayAgeGroup = m.AwayTeam.AgeGroup,
            AwayImage = m.AwayTeam.Academy.Image,
            AwayScore = m.AwayScore,
        })
        .ToListAsync();
        }

        public async Task<IReadOnlyList<MatchDto>> GetAcademyMatches(Guid id)
        {
            return await _ctx.Matches
        .Include(m => m.HomeTeam).ThenInclude(t => t.Academy)
        .Include(m => m.AwayTeam).ThenInclude(t => t.Academy)
        .Where(m =>
            m.HomeTeam.AcademyId == id ||
            m.AwayTeam.AcademyId == id)
        .Select(m => new MatchDto
        {
            Id = m.Id,
            KickOff = m.Kickoff,

            HomeId = m.HomeId,
            HomeName = m.HomeTeam.Academy.Name,
            HomeImage = m.HomeTeam.Academy.Image,
            HomeAgeGroup = m.HomeTeam.AgeGroup,
            HomeScore = m.HomeScore,

            AwayId = m.AwayId,
            AwayName = m.AwayTeam.Academy.Name,
            AwayImage = m.AwayTeam.Academy.Image,
            AwayAgeGroup = m.AwayTeam.AgeGroup,
            AwayScore = m.AwayScore,
        })
        .ToListAsync();
        }

        public async Task<MatchDto?> GetMatchByIdAsync(Guid id)
        {
            return await _ctx.Matches
        .Include(m => m.HomeTeam)
            .ThenInclude(ht => ht.Academy)
        .Include(m => m.AwayTeam)
            .ThenInclude(at => at.Academy)
        .Where(m => m.Id == id)
        .Select(m => new MatchDto
        {
            Id = m.Id,
            KickOff = m.Kickoff,

            HomeId = m.HomeId,
            HomeName = m.HomeTeam.Academy.Name,
            HomeImage = m.HomeTeam.Academy.Image,
            HomeAgeGroup = m.HomeTeam.AgeGroup,
            HomeScore = m.HomeScore,

            AwayId = m.AwayId,
            AwayName = m.AwayTeam.Academy.Name,
            AwayImage = m.AwayTeam.Academy.Image,
            AwayAgeGroup = m.AwayTeam.AgeGroup,
            AwayScore = m.AwayScore,
        })
        .FirstOrDefaultAsync();
        }


    }
}

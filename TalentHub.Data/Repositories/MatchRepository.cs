using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using TalentHub.Business.Dtos;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.MatchDto;

namespace TalentHub.Data.Repositories
{
    public class MatchRepository : Repository<Match>,IMatchRepository
    {
        private readonly ApplicationDbContext _ctx;
        public MatchRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<IReadOnlyList<MatchReadDto>> GetAllWithAcademyNamesAsync()
        {
            
            return await _ctx.Matches
        .Include(m => m.HomeTeam)
            .ThenInclude(ht => ht.Academy)
        .Include(m => m.AwayTeam)
            .ThenInclude(at => at.Academy)
        .Select(m => new MatchReadDto
        {
            Id = m.Id,
            KickOff = m.Kickoff,
            Venue = m.Venue,

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

        public async Task<IReadOnlyList<MatchReadDto>> GetAcademyMatches(Guid id)
        {
            return await _ctx.Matches
        .Include(m => m.HomeTeam).ThenInclude(t => t.Academy)
        .Include(m => m.AwayTeam).ThenInclude(t => t.Academy)
        .Where(m =>
            m.HomeTeam.AcademyId == id ||
            m.AwayTeam.AcademyId == id)
        .Select(m => new MatchReadDto
        {
            Id = m.Id,
            KickOff = m.Kickoff,
            Venue = m.Venue,

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

        public async Task<MatchReadDto?> GetMatchByIdAsync(Guid id)
        {
            return await _ctx.Matches
        .Include(m => m.HomeTeam)
            .ThenInclude(ht => ht.Academy)
        .Include(m => m.AwayTeam)
            .ThenInclude(at => at.Academy)
        .Where(m => m.Id == id)
        .Select(m => new MatchReadDto
        {
            Id = m.Id,
            KickOff = m.Kickoff,
            Venue = m.Venue,

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

        public async Task<IReadOnlyList<MatchReadDto>> GetAllWithAcademyNamesKPagenationAsync(
    int pageSize,
    DateTime? key = null,            // آخر Kickoff ظهر (ممكن null لأول صفحة)
    Guid? lastId = null,             // آخر Id ظهر عند نفس الـ Kickoff (ممكن null)
    bool forward = true,             // true للأمام، false للخلف
    CancellationToken ct = default)
        {
            var q = _ctx.Matches.AsNoTracking();

            if (key.HasValue)
            {
                if (forward)
                {
                    q = q.Where(m =>
                        m.Kickoff > key.Value ||
                        (m.Kickoff == key.Value && (lastId.HasValue ? m.Id.CompareTo(lastId.Value) > 0 : true))
                    );
                }
                else
                {
                    q = q.Where(m =>
                        m.Kickoff < key.Value ||
                        (m.Kickoff == key.Value && (lastId.HasValue ? m.Id.CompareTo(lastId.Value) < 0 : true))
                    );
                }
            }

            q = forward
                ? q.OrderBy(m => m.Kickoff).ThenBy(m => m.Id)
                : q.OrderByDescending(m => m.Kickoff).ThenByDescending(m => m.Id);

            return await q
                .Select(m => new MatchReadDto
                {
                    Id = m.Id,
                    KickOff = m.Kickoff,
                    Venue = m.Venue,
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
                .Take(pageSize)
                .ToListAsync(ct);
        }
    }
}

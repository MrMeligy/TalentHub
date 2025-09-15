using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using TalentHub.Core.Entities;

namespace TalentHub.Data.Repositories
{
    public class PlayerMatchRepository : Repository<PlayerMatch>, IPlayerMatchRepository
    {
        private readonly ApplicationDbContext _ctx;
        public PlayerMatchRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }
        public async Task<IReadOnlyList<PlayerMatch>> GetByMatch(Guid matchId)
        {
            return await _ctx.PlayerMatches.Where(pm=>pm.MatchId==matchId).ToListAsync();
        }

        public async Task<IReadOnlyList<PlayerMatch>> GetByPlayer(Guid playerId)
        {

            return await _ctx.PlayerMatches.Where(pm => pm.PlayerId == playerId).ToListAsync();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using TalentHub.Core.Entities;

namespace TalentHub.Data.Repositories
{
    public class PlayerSkillRepository : Repository<PlayerSkill>, IPlayerSkillRepository
    {
        private readonly ApplicationDbContext _ctx;
        public PlayerSkillRepository(ApplicationDbContext ctx) : base(ctx) 
        {
            _ctx = ctx;
        }
        public async Task<IReadOnlyList<PlayerSkill>> GetByPlayerAsync(Guid playerId)
        {
            return await _ctx.PlayerSkills.Where(p => p.PlayerId == playerId).ToListAsync();
        }
    }
}

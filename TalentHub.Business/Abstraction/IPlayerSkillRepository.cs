using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Abstraction
{
    public interface IPlayerSkillRepository : IRepository<PlayerSkill>
    {
        public Task<IReadOnlyList<PlayerSkill>> GetByPlayerAsync(Guid playerId);
    }
}

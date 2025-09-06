using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Contracts
{
    public interface IPlayerSkillService
    {
        Task<IReadOnlyList<PlayerSkill>> GetAllAsync();
        Task<PlayerSkill?> GetByIdAsync(Guid id);
        Task<PlayerSkill> CreateAsync(PlayerSkill skill);
        Task<bool> UpdateAsync(Guid id, PlayerSkill updated);
        Task<bool> DeleteAsync(Guid id);
    }
}

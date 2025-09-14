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
    public class PlayerSkillService : IPlayerSkillService
    {
        private readonly IUnitOfWork _uow;
        public PlayerSkillService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<PlayerSkill> CreateAsync(PlayerSkill skill)
        {
            await _uow.PlayerSkills.AddAsync(skill);
            await _uow.SaveChangesAsync();
            return skill;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _uow.PlayerSkills.GetByIdAsync(id);
            if (existing is null) return false;
            _uow.PlayerSkills.Remove(existing);
            await _uow.SaveChangesAsync();
            return true;
        }

        public async Task<IReadOnlyList<PlayerSkill>> GetAllAsync(Guid playerId) => await _uow.PlayerSkills.GetByPlayerAsync(playerId);


        public async Task<PlayerSkill?> GetByIdAsync(Guid id)=> await _uow.PlayerSkills.GetByIdAsync(id) ;

        public async Task<bool> UpdateAsync(Guid id, PlayerSkill updated)
        {
            var existing = await _uow.PlayerSkills.GetByIdAsync(id);
            if (existing is null) return false;
            existing.Skill = updated.Skill;
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}

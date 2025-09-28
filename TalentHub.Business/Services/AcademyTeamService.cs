using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using TalentHub.Business.Contracts;
using static TalentHub.Business.Dtos.AcademyTeamDto;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Services
{
    public class AcademyTeamService : IAcademyTeamService
    {
        private readonly IUnitOfWork _uow;
        public AcademyTeamService(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public async Task<AcademyTeam> CreateAsync(AcademyTeam academyTeam)
        {
            await _uow.AcademyTeams.AddAsync(academyTeam);
            await _uow.SaveChangesAsync();
            return academyTeam;
        }

        public async Task<bool> DeleteAsync(Guid id)
        {
            var existing = await _uow.AcademyTeams.GetByIdAsync(id);
            if(existing is null) return false;
            _uow.AcademyTeams.Remove(existing);
            await _uow.SaveChangesAsync();
            return true;
        }

        public Task<AcademyTeamReadDto?> GetAcademyTeamById(Guid academyTeamId)
            => _uow.AcademyTeams.GetAcademyTeamById(academyTeamId);

        public async Task<IReadOnlyList<AcademyTeamReadDto>> GetAcademyTeams(Guid academyId) 
            => await _uow.AcademyTeams.GetAcademyTeams(academyId);


        public Task<AcademyTeam?> GetByIdAsync(Guid id) => _uow.AcademyTeams.GetByIdAsync(id);
        

        public async Task<bool> UpdateAsync(Guid id, AcademyTeam updated)
        {
            var existing = await _uow.AcademyTeams.GetByIdAsync(id);
            if(existing is null) return false;
            existing.AgeGroup = updated.AgeGroup;
            await _uow.SaveChangesAsync();
            return true;
        }
    }
}

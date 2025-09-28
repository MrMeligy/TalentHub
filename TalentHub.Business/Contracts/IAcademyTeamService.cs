using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.AcademyTeamDto;

namespace TalentHub.Business.Contracts
{
    public interface IAcademyTeamService
    {

        Task<IReadOnlyList<AcademyTeamReadDto>> GetAcademyTeams(Guid academyId);
        Task<AcademyTeamReadDto> GetAcademyTeamById(Guid academyTeamId);
        Task<AcademyTeam> CreateAsync(AcademyTeam academyTeam);
        Task<bool> UpdateAsync(Guid id, AcademyTeam updated);
        Task<bool> DeleteAsync(Guid id);
    }
}

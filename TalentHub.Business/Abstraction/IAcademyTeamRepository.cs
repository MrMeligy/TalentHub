using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TalentHub.Business.Dtos.AcademyTeamDto;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Abstraction
{
    public interface IAcademyTeamRepository : IRepository<AcademyTeam>
    {
        Task<IReadOnlyList<AcademyTeamReadDto>> GetAcademyTeams(Guid academyId);
        Task<AcademyTeamReadDto?> GetAcademyTeamById(Guid academyTeamId);
    }
}

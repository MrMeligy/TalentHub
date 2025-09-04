using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Contracts
{
    public interface IAcademyTeamService
    {
        Task<IReadOnlyList<AcademyTeam>> GetAllAsync();
        Task<AcademyTeam?> GetByIdAsync(Guid id);
        Task<AcademyTeam> CreateAsync(AcademyTeam academyTeam);
        Task<bool> UpdateAsync(Guid id, AcademyTeam updated);
        Task<bool> DeleteAsync(Guid id);
    }
}

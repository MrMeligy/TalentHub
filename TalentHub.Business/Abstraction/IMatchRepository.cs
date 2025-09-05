using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Dtos;
using TalentHub.Core.Entities;


namespace TalentHub.Business.Abstraction
{
    public interface IMatchRepository : IRepository<Match>
    {
        Task<IReadOnlyList<MatchDto>> GetAllWithAcademyNamesAsync();
        Task<IReadOnlyList<MatchDto>> GetAcademyMatches(Guid id);
        Task<MatchDto?> GetMatchByIdAsync(Guid id);

    }
}

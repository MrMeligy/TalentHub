using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;
using TalentHub.Data.Dtos;


namespace TalentHub.Data.Repositories
{
    public interface IMatchRepository : IRepository<Match>
    {
        Task<IReadOnlyList<MatchDto>> GetAllWithAcademyNamesAsync();
        Task<IReadOnlyList<MatchDto>> GetAcademyMatches(Guid id);
        Task<MatchDto?> GetMatchByIdAsync(Guid id);

    }
}

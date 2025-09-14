using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Dtos;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.MatchDto;


namespace TalentHub.Business.Abstraction
{
    public interface IMatchRepository : IRepository<Match>
    {
        Task<IReadOnlyList<MatchReadDto>> GetAllWithAcademyNamesAsync();
        Task<IReadOnlyList<MatchReadDto>> GetAcademyMatches(Guid id);
        Task<MatchReadDto?> GetMatchByIdAsync(Guid id);

    }
}

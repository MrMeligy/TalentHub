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
        Task<IReadOnlyList<MatchReadDto>> GetAllWithAcademyNamesKPagenationAsync(int pageSize,
            DateTime? key = null,            // آخر Kickoff ظهر (ممكن null لأول صفحة)
            Guid? lastId = null,             // آخر Id ظهر عند نفس الـ Kickoff (ممكن null)
            bool forward = true,             // true للأمام، false للخلف
            CancellationToken ct = default);
        Task<IReadOnlyList<MatchReadDto>> GetAcademyMatches(Guid id);
        Task<MatchReadDto?> GetMatchByIdAsync(Guid id);

    }
}

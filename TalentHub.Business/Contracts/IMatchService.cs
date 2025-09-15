using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Dtos;
using TalentHub.Core.Entities;
using static TalentHub.Business.Dtos.MatchDto;

namespace TalentHub.Business.Contracts
{
    public interface IMatchService
    {
        Task<IReadOnlyList<MatchReadDto>> GetAllAsync();
        Task<IReadOnlyList<MatchReadDto>> GetAllAsyncKP(int pageSize,
            DateTime? key = null,            // آخر Kickoff ظهر (ممكن null لأول صفحة)
            Guid? lastId = null,             // آخر Id ظهر عند نفس الـ Kickoff (ممكن null)
            bool forward = true,             // true للأمام، false للخلف
            CancellationToken ct = default);
        Task<MatchReadDto?> GetByIdAsync(Guid id);
        Task<Match> CreateAsync(Match match);
        Task<bool> UpdateAsync(Guid id, Match updated);
        Task<bool> DeleteAsync(Guid id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Dtos;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Contracts
{
    public interface IMatchService
    {
        Task<IReadOnlyList<MatchDto>> GetAllAsync();
        Task<MatchDto?> GetByIdAsync(Guid id);
        Task<Match> CreateAsync(Match match);
        Task<bool> UpdateAsync(Guid id, Match updated);
        Task<bool> DeleteAsync(Guid id);
    }
}

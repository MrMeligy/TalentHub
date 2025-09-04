using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Contracts
{
    public interface IAcademyService
    {
        Task<IReadOnlyList<Academy>> GetAllAsync();
        Task<Academy?> GetByIdAsync(Guid id);
        Task<Academy> CreateAsync(Academy academy);
        Task<bool> UpdateAsync(Guid id, Academy updated);
        Task<bool> DeleteAsync(Guid id);
    }
}

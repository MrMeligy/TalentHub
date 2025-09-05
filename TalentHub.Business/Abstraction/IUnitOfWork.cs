using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Abstraction
{
    public interface IUnitOfWork
    {
        IRepository<Academy> Academies { get; }
        IRepository<AcademyTeam> AcademyTeams { get; }
        IMatchRepository Matches { get; }
        IPlayerRepository Players { get; }
        IRepository<PlayerMatch> PlayerMatches { get; }
        IRepository<PlayerSkill> PlayerSkills { get; }
        Task<int> SaveChangesAsync();
    }
}

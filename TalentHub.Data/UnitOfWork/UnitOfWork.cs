using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using TalentHub.Core.Entities;
using TalentHub.Data.Repositories;

namespace TalentHub.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        ApplicationDbContext _ctx;
        public IRepository<Academy> Academies { get; }
        public IRepository<AcademyTeam> AcademyTeams { get; }
        public IMatchRepository Matches { get; }
        public IPlayerRepository Players { get; }
        public IRepository<PlayerMatch> PlayerMatches { get; }
        public IRepository<PlayerSkill> PlayerSkills { get; }
        public UnitOfWork(ApplicationDbContext ctx)
        {
            _ctx = ctx;
            Academies = new Repository<Academy>(_ctx);
            AcademyTeams = new Repository<AcademyTeam>(_ctx);
            Players = new PlayerRepository(_ctx);
            Matches = new MatchRepository(_ctx);
            PlayerMatches = new Repository<PlayerMatch>(_ctx);
            PlayerSkills = new Repository<PlayerSkill>(_ctx);

        }
        public Task<int> SaveChangesAsync() => _ctx.SaveChangesAsync();

        public async ValueTask DisposeAsync() => await _ctx.DisposeAsync();

    }
}

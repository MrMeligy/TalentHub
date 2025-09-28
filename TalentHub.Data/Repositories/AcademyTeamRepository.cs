using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Business.Abstraction;
using static TalentHub.Business.Dtos.AcademyTeamDto;
using TalentHub.Core.Entities;

namespace TalentHub.Data.Repositories
{
    public class AcademyTeamRepository : Repository<AcademyTeam>, IAcademyTeamRepository
    {
        private readonly ApplicationDbContext _ctx;
        public AcademyTeamRepository(ApplicationDbContext ctx) : base(ctx)
        {
            _ctx = ctx;
        }

        public async Task<AcademyTeamReadDto?> GetAcademyTeamById(Guid academyTeamId)
        {
            return await _ctx.AcademyTeams
                .Where(at => at.Id == academyTeamId)
                .Select(at => new AcademyTeamReadDto
                {
                    Id = at.Id,
                    AcademyId = at.AcademyId,
                    AcademyName = at.Academy.Name,
                    AgeGroup = at.AgeGroup
                }).FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyList<AcademyTeamReadDto>> GetAcademyTeams(Guid academyId)
        {
            return await _ctx.AcademyTeams
                .Where(at=>at.AcademyId==academyId)
                .Select(at=>new AcademyTeamReadDto {
                Id = at.Id,
                AcademyId = at.AcademyId,
                AcademyName = at.Academy.Name,
                AgeGroup = at.AgeGroup
            }).ToListAsync();
        }
    }
}

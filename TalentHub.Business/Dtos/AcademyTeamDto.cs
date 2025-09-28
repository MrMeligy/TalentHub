using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Dtos
{
    public class AcademyTeamDto
    {
        public record AcademyTeamReadDto
        {
            public Guid Id { get; set; }
            public Guid AcademyId { get; set; }
            public string AcademyName { get; set; }
            public string AgeGroup { get; set; }

        }
        public record AcademyTeamCreateDto
        {
            public Guid AcademyId { get; set; }
            public string AgeGroup { get; set; }
        }
        public record AcademyTeamUpdateDto : AcademyTeamCreateDto { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalentHub.Core.Entities;

namespace TalentHub.Business.Dtos
{
    public class PlayerSkillDto
    {
        public record PlayerSkillReadDto
        {
            public Guid Id { get; set; }
            public Guid PlayerId { get; set; }
            public string Skill { get; set; }
        }
        public record PlayerSkillCreateDto
        {
            public Guid PlayerId { get; set; }
            public string Skill { get; set; }
        }

    }
}

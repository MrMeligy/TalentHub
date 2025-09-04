using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentHub.Core.Entities
{
    public class PlayerSkill
    {
        public Guid Id { get; set; }
        public Guid PlayerId { get; set; }
        public string Skill { get; set; }
        public Player Player { get; set; }
    }
}

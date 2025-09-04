using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentHub.Core.Entities
{
    public class AcademyTeam
    {
        public Guid Id { get; set; }
        public Guid AcademyId { get; set; }
        public string AgeGroup { get; set; }
        public Academy Academy { get; set; }
        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}

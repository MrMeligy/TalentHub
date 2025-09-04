using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentHub.Core.Entities
{
    public class Academy
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Describtion { get; set; }
        public float? Rating { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public bool Is_Partner { get; set; }
        public ICollection<AcademyTeam> AcademyTeams { get; set; } = new List<AcademyTeam>();
    }
}

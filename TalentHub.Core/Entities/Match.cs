using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentHub.Core.Entities
{
    public class Match
    {
        public Guid Id { get; set; }
        public Guid HomeId { get; set; }
        public Guid AwayId { get; set; }
        public string Venue { get; set; }
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
        public DateTime Kickoff { get; set; }
        public AcademyTeam HomeTeam { get; set; }
        public AcademyTeam AwayTeam { get; set; }
        public ICollection<PlayerMatch> PlayerMatches { get; set; } = new List<PlayerMatch>();
    }
}

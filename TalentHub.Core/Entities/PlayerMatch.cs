using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TalentHub.Core.Entities
{
    public class PlayerMatch
    {
        public Guid Id { get; set; }
        public Guid MatchId { get; set; }
        public Guid PlayerId { get; set; }
        public Guid AcademyTeamId { get; set; }
        public int Minutes { get; set; }
        public int Goals { get; set; }
        public int Assists { get; set; }
        public int Saves { get; set; }
        public int Tackles { get; set; }
        public int SuccessTackles { get; set; }
        public int Interceptions { get; set; }
        public float Rating { get; set; }
        public Match Match { get; set; }
        public Player Player { get; set; }
        public AcademyTeam AcademyTeam { get; set; }
    }
}

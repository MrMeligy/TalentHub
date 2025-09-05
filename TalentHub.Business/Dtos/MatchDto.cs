namespace TalentHub.Business.Dtos
{
        public class MatchDto
        {
            public Guid Id { get; set; }
            public DateTime KickOff { get; set; }
            public Guid HomeId { get; set; }
            public string HomeImage { get; set; }
            public string HomeName { get; set; }
            public string HomeAgeGroup { get; set; }
            public int HomeScore { get; set; }
            public Guid AwayId { get; set; }
            public string AwayImage { get; set; }
            public string AwayName { get; set; }
            public string AwayAgeGroup { get; set; }
            public int AwayScore { get; set; }
        }
    }


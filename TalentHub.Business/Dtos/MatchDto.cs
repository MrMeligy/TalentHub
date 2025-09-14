namespace TalentHub.Business.Dtos
{
    public class MatchDto
    {


        public record class MatchReadDto
        {
            public Guid Id { get; set; }
            public DateTime KickOff { get; set; }
            public string Venue { get; set; }
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
        public record class MatchCreateDto
        {
            public DateTime KickOff { get; set; }
            public string Venue { get; set; }
            public Guid HomeId { get; set; }
            public int HomeScore { get; set; }
            public Guid AwayId { get; set; }
            public int AwayScore { get; set; }
        }
        public record class MatchUpdateDto : MatchCreateDto { };
    }
}


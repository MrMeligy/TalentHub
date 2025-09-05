namespace TalentHub.Business.Dtos
{
    public class PlayerDto
    {
        public Guid Id { get; set; }
        public Guid AcademyTeamId { get; set; }
        public string Name { get; set; }
        public string TeamName { get; set; }
        public string AcademyImage { get; set; }
        public string Image { get; set; }
        public string FavouriteFoot { get; set; }
        public int Weight { get; set; }
        public int Height { get; set; }
        public int? TotalMatches { get; set; }
        public int TotalGoals { get; set; }
        public int TotalAssists { get; set; }
        public string Position { get; set; }
        public int ShirtNumber { get; set; }
        public float Rating { get; set; }
        public int TotalSaves { get; set; }
        public int TotalInterceptions { get; set; }
        public int TotalTackles { get; set; }
        public int SuccessTackles { get; set; }
        public int TotalMinutes { get; set; }
        public string Nationality { get; set; }
        public DateOnly DOB { get; set; }
    }
}

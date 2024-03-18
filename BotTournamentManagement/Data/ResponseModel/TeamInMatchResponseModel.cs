namespace BotTournamentManagement.Data.ResponseModel
{
    public class TeamInMatchResponseModel
    {
        public string Id { get; set; }
        public string TeamId { get; set; }
        public string TeamName { get; set; }
        public string MatchId { get; set; }
        public string MatchKeyId { get; set; }
        public double? Score { get; set; }
        public TimeSpan? Duration { get; set; }
        public string? Result { get; set; }
    }
}

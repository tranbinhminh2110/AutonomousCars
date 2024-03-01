namespace BotTournamentManagement.Data.RequestModel.MatchModel
{
    public class MatchCreatedModel
    {
        public string KeyId { get;set; }
        public string MapId { get; set; }
        public DateTimeOffset MatchDate { get; set; }
        public string RoundId { get; set; }
        public string TournamentId { get; set; }

    }
}

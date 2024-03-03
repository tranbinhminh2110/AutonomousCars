namespace BotTournamentManagement.Data.RequestModel.MatchModel
{
    public class MatchUpdateModel
    {
        public string MapId { get; set; }
        public DateTimeOffset MatchDate { get; set; }
        public string RoundId { get; set; }
        public string TournamentId { get; set; }
        public string KeyId { get; set; }
    }
}

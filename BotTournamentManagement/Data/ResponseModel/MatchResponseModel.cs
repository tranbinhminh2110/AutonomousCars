namespace BotTournamentManagement.Data.ResponseModel
{
    public class MatchResponseModel
    {
        public string Id { get; set; }
        public string KeyId { get; set; }
        public string MapId { get; set; }
        public string MapName { get; set; }
        public DateTimeOffset MatchDate { get; set; }
        public string RoundId { get; set; }
        public string RoundName { get; set; }
        public string TournamentId { get; set; }
        public string TournamentName { get; set; }
    }
}

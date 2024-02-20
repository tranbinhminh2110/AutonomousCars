namespace BotTournamentManagement.Data.ResponseModel
{
    public class MatchResponseModel
    {
        public string MapId { get; set; }
        public DateTimeOffset MatchDate { get; set; }
        public string RoundId { get; set; }
        public string TournamentId { get; set; }
    }
}

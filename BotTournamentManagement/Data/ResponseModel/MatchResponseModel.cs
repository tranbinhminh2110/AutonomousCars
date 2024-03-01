namespace BotTournamentManagement.Data.ResponseModel
{
    public class MatchResponseModel
    {
        public string Id { get; set; }
        public string KeyId { get; set; }
        public MapResponseModel MapResponseModel { get; set; }
        public DateTimeOffset MatchDate { get; set; }
        public RoundResponseModel RoundResponseModel { get; set; }
        public TournamentResponseModel TournamentResponseModel { get; set; }
    }
}

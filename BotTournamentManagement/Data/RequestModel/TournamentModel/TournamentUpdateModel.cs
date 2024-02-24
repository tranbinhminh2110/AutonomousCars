namespace BotTournamentManagement.Data.RequestModel.TournamentModel
{
    public class TournamentUpdateModel
    {
        public string Id {  get; set; }
        public string KeyId { get; set; }
        public string TournamentName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
    }
}

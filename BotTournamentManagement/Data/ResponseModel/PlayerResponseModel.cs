namespace BotTournamentManagement.Data.ResponseModel
{
    public class PlayerResponseModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Dob { get; set; }
        public string KeyId { get; set; }
        public string TeamId { get; set; }
        public string TeamName { get; set; }
    }
}

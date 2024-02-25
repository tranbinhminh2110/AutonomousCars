namespace BotTournamentManagement.Data.RequestModel.PlayModel
{
    public class PlayerUpdatedModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTimeOffset Dob { get; set; }
        public string KeyId { get; set; }
        public string TeamId { get; set; }
    }
}

namespace BotTournamentManagement.Data.RequestModel.PlayModel
{
    public class PlayerCreateModelWithTeam
    {
        public string Name { get; set; }
        public DateTimeOffset Dob { get; set; }
        public string KeyId { get; set; }
    }
}

namespace BotTournamentManagement.Data.RequestModel.TeamInMatchModel
{
    public class TeamInMatchUpdateModel
    {
        public string Id { get; set; }
        public double Score { get; set; }
        public TimeSpan Duration { get; set; }
        public bool isWinner {  get; set; }
    }
}

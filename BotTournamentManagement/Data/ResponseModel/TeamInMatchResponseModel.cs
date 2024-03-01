using System.ComponentModel.DataAnnotations;

namespace BotTournamentManagement.Data.ResponseModel
{
    public class TeamInMatchResponseModel
    {
        public string Id { get; set; }
        public TeamResponseModelWithoutPlayer teamResponse { get; set; }
        public double? Score { get; set; }
        public TimeSpan? Duration { get; set; }
        public bool? isWinner { get; set; }
    }
}

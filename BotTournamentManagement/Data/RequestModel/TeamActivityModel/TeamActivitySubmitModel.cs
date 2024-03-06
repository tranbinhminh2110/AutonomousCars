using System.ComponentModel.DataAnnotations;

namespace BotTournamentManagement.Data.RequestModel.TeamActivityModel
{
    public class TeamActivitySubmitModel
    {
        public string ActivityTypeId { get; set; }
        public string TeamInMatchId { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public string? Duration { get; set; }
        public double? Score { get; set; }
        public int? Violation { get; set; }
        
    }
}

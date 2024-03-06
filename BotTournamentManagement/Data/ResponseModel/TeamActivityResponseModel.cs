using System.ComponentModel.DataAnnotations;

namespace BotTournamentManagement.Data.ResponseModel
{
    public class TeamActivityResponseModel
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public double? Score { get; set; }
        public int? Violation { get; set; }
        public string ActivityTypeId { get; set; }
        public string ActivityTypeName { get; set; }
        public string TeamInMatchId { get; set; }
        public string TeamId { get; set; }
        public string TeamKeyId { get; set; }
        public string TeamName { get; set; }
        public string MatchId { get; set; }
        public string MatchKeyId { get; set; }
        
    }
}

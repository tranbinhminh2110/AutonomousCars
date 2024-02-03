using BotTournamentManagement.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace BotTournamentManagement.Data.Entities
{
    [Table("TeamActivity")]
    public class TeamActivityEntity : BaseEntity
    {
        [MaxLength(4000)]
        public string? Description { get; set; }
        public DateTimeOffset? StartTime { get; set; }
        public DateTimeOffset? EndTime { get; set; }
        public TimeSpan? Duration { get; set; }
        public double? Score { get; set; }
        public int? Violation { get; set; }
        [Required]
        public string ActivityTypeId { get; set; }
        [Required]
        public string TeamInMatchId { get; set; }

        [ForeignKey(nameof(ActivityTypeId))]
        public virtual ActivityTypeEntity ActivityType { get; set; }

        [ForeignKey(nameof(TeamInMatchId))]
        public virtual TeamInMatchEntity TeamInMatch { get;set; }
    }
}

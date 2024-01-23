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
        public DateTimeOffset StartTime { get; set; }
        public DateTimeOffset EndTime { get; set; }
        [Required]
        public string MatchId { get; set; }
        
        [ForeignKey(nameof(MatchId))]
        public virtual MatchEntity Match { get; set; }
        [Required]
        public string TeamId { get; set; }
        
        [ForeignKey(nameof(TeamId))]
        public virtual TeamEntity Team { get; set; }

        public TimeSpan? Duration { get; set; }
        public double? Score { get; set; }
        public int? Violation { get; set; }
        [Required]
        public string ActivityTypeId { get; set; }
        
        [ForeignKey(nameof(ActivityTypeId))]
        public virtual ActivityTypeEntity ActivityType { get; set; }
    }
}

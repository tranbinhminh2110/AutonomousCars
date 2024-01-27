using BotTournamentManagement.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("TeamInMatch")]
    public class TeamInMatchEntity : BaseEntity
    {
        [Required]
        public string TeamId { get; set; }
        [Required]
        public string MatchId { get; set; }
        public double? Score { get; set; }
        public double? Duration { get; set; }
        public bool? isWinner { get; set; }
        [ForeignKey(nameof(TeamId))]
        public virtual TeamEntity Team { get; set; }

        [ForeignKey(nameof(MatchId))]
        public virtual MatchEntity Match { get; set; }    
        public ICollection<TeamActivityEntity>? TeamActivities { get; set; }

    }
}

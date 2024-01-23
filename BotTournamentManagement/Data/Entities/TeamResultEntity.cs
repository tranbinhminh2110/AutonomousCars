using BotTournamentManagement.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("TeamResult")]
    public class TeamResultEntity : BaseEntity
    {
        [Required]
        public string MatchId;
        
        [ForeignKey(nameof(MatchId))]
        public virtual MatchEntity Match { get; set; }
        
        [Required]
        public string TeamId;
        
        [ForeignKey(nameof(TeamId))]
        public virtual TeamEntity Team { get; set;}

        public double Score { get; set; }
        public double Duration { get; set; }

        public bool isWinner { get; set; }


    }
}

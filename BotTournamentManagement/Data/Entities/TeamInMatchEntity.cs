using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("TeamInMatch")]
    public class TeamInMatchEntity
    {
        public string TeamId { get; set; }
        public string MatchId { get; set; }
    }
}

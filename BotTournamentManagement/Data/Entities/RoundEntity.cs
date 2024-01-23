using BotTournamentManagement.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("Round")]
    public class RoundEntity : BaseEntity
    {
        public string RoundName { get; set; }
        public ICollection<MatchEntity> Matches { get; set; }
    }
}

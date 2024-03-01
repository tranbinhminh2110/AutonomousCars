using BotTournamentManagement.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("Match")]
    public class MatchEntity : IdentityOptionalEntity
    {
        [Required]
        public string MapId { get; set; }
        public DateTimeOffset MatchDate{ get; set; }
        [Required]
        public string RoundId{ get; set;}
        [Required]
        public string TournamentId { get; set; }
        
        [ForeignKey(nameof(MapId))]
        public virtual MapEntity Map { get; set; }
        
        [ForeignKey(nameof(RoundId))]
        public virtual RoundEntity Round { get; set; }
        [ForeignKey(nameof(TournamentId))]
        public virtual TournamentEntity Tournament { get; set; }
    }
}

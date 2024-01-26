using BotTournamentManagement.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("Player")]
    public class PlayerEntity : IdentityOptionalEntity
    {
        public string Name { get; set; }
        public DateTimeOffset Dob { get; set; }

        [Required]
        public string TeamId { get; set; }
        
        [ForeignKey(nameof(TeamId))]
        public virtual TeamEntity Team { get; set; }
    }
}

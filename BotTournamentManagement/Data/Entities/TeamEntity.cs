using BotTournamentManagement.Data.Entities.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("Team")]
    public class TeamEntity : IdentityOptionalEntity
    {
        public string TeamName { get; set; }
        
        [Required]
        public string HighSchoolId { get; set; }
        
        [ForeignKey(nameof(HighSchoolId))]
        public virtual HighSchoolEntity HighSchool { get; set; }
        public ICollection<PlayerEntity> Players { get; set; }

    }
}

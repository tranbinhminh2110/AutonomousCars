using BotTournamentManagement.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("ActivityType")]
    public class ActivityTypeEntity : BaseEntity
    {
        public string TypeName { get; set; }
        public ICollection<TeamActivityEntity> TeamActivities { get; set; }
    }
}

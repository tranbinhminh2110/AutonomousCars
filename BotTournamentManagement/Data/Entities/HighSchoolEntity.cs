using System.ComponentModel.DataAnnotations.Schema;
using BotTournamentManagement.Data.Entities.Base;

namespace BotTournamentManagement.Data.Entities
{
    [Table("HighSchool")]
    public class HighSchoolEntity : IdentityOptionalEntity
    {
        public string HighSchoolName { get; set; }
        public ICollection <TeamEntity> Teams { get; set; }
    }
}

using BotTournamentManagement.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("Tournament")]
    public class TournamentEntity : IdentityOptionalEntity
    {
        public string TournamentName { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset EndDate { get; set;}
        public ICollection<MatchEntity> Matches { get; set; }
    }
}

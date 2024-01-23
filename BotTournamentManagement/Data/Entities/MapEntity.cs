using BotTournamentManagement.Data.Entities.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("Map")]
    public class MapEntity : IdentityOptionalEntity
    {
        public string MapName { get; set; }
    }
}

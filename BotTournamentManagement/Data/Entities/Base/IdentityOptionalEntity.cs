using Microsoft.EntityFrameworkCore;

namespace BotTournamentManagement.Data.Entities.Base
{
    [Index(nameof(KeyId), IsUnique = true, Name = "Index_KeyId")]
    public abstract class IdentityOptionalEntity : BaseEntity
    {
        public string KeyId { get; set; }
    }
}

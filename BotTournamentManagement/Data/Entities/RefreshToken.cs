using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("RefreshToken")]
    public class RefreshToken
    {
        public string Id { get; set; }

        [ForeignKey(nameof(UserId))]
        public UserEntity User { get; set; }
        public string UserId { get; set; }

        public string? Token { get; set; }
        public DateTime Expires { get; set; }
        public bool IsActive { get; set; }
    }
}

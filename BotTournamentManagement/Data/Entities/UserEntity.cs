using BotTournamentManagement.Data.Entities.Base;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BotTournamentManagement.Data.Entities
{
    [Table("User")]
    public class UserEntity : IdentityOptionalEntity
    {
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        [Required]
        [MaxLength(250)]
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Role { get; set; }
    }
}

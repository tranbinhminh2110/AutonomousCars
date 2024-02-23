using System.ComponentModel.DataAnnotations;

namespace BotTournamentManagement.Data.RequestModel.PlayModel
{
    public class PlayerCreatedModel
    {
        public string Name { get; set; }
        public DateTimeOffset Dob { get; set; }
        public string KeyId { get; set; }

    }
}

using BotTournamentManagement.Data.Enum;

namespace BotTournamentManagement.Data.ResponseModel
{
    public class UserResponseModel
    {
        public string KeyId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string FullName { get; set; }
        public Role Role { get; set; }
    }
}

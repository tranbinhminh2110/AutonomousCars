using BotTournamentManagement.Data.Enum;

namespace BotTournamentManagement.Data.RequestModel.UserModel
{
    public class UserRequestModel
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public Role Role { get; set; }
    }
}

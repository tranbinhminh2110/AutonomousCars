namespace BotTournamentManagement.Data.ResponseModel
{
    public class ResponseLoginModel
    {
        public string UserName {  get; set; }
        public string UserEmail { get; set; }
        public string FullName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
    }
}

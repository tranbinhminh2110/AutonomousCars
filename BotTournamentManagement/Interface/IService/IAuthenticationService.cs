using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.Interface.IService
{
    public interface IAuthenticationService
    {
        ResponseLoginModel Authenticator(RequestLoginModel model);
    }
}

using BotTournamentManagement.Data.RequestModel.UserModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.Interface.IService
{
    public interface IAuthenticationService
    {
        ResponseLoginModel Authenticator(RequestLoginModel model);
    }
}

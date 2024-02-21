using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.UserModel;

namespace BotTournamentManagement.Interface.IRepository
{
    public interface IUserRepository:IBaseRepository<UserEntity>
    {
        UserEntity GetUser(RequestLoginModel requestLoginModel);
    }
}

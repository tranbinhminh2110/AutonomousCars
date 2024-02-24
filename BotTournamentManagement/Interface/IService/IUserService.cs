using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.UserModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.Interface.IService
{
    public interface IUserService
    {
        List<UserResponseModel> GetUsersList();
        List<UserResponseModel> SearchUser(string searchkey);
        UserResponseModel GetUserById(string id);
        void AddNewUser(UserRequestModel userRequestModel);
        void DeleteUser(string id);
        void UpdateUser(UserRequestModel userRequestModel);


    }
}

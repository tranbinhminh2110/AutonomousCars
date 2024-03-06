using BotTournamentManagement.Data.RequestModel.TeamActivityModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.Interface.IService
{
    public interface ITeamActivityService
    {
        List<TeamActivityResponseModel> GetAllActivities();
        void AddNewActivity(TeamActivitySubmitModel teamActivitySubmitModel);
        void RemoveActivity(string id);
    }
}

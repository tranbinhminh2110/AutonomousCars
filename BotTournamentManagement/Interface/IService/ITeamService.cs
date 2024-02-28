using BotTournamentManagement.Data.RequestModel.TeamModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface ITeamService
    {
        List<TeamResponseModel> GetAllTeams();
        void CreateANewTeam(TeamCreatedModel teamCreatedModel);
        void UpdateATeam(string id, TeamUpdateModel teamUpdateModel);
        void DeleteATeam(string id);
        TeamResponseModel GetTeamById(string id);
    }
}

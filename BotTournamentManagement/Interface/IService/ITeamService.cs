using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface ITeamService
    {
        List<TeamResponseModel> GetAllTeams();
        void CreateANewTeam(TeamCreatedModel teamCreatedModel);
        void UpdateANewTeam(string id, [FromForm] TeamUpdateModel teamCreatedModel);
        void DeleteATeam(string id);
        TeamResponseModel GetTeamById(string id);
    }
}

using BotTournamentManagement.Data.RequestModel.TeamInMatchModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.Interface.IService
{
    public interface ITeamInMatchService
    {
        List<TeamInMatchResponseModel> GetTeamInAMatch(string matchId);
        void AddTeamToMatch(TeamInMatchCreatedModel teamInMatchCreatedModel);
        void RemoveTeamFromMatch(string id);
        void UpdateFinalResult(string id, TeamInMatchUpdateModel teamInMatchUpdateModel);
        TeamInMatchResponseModel GetTeamInMatchById(string id);
    }
}

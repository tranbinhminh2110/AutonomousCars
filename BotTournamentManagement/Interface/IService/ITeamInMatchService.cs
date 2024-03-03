using BotTournamentManagement.Data.RequestModel.TeamInMatchModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.Interface.IService
{
    public interface ITeamInMatchService
    {
        List<TeamInMatchResponseModel> GetTeamInAMatch(string matchId);
        void AddTeamToMatch(string matchId, TeamInMatchCreatedModel teamInMatchCreatedModel);
        void RemoveTeamFromMatch(string teamId,string matchId);
        void UpdateFinalResult(string teamId,string matchId, TeamInMatchUpdateModel teamInMatchUpdateModel);
    }
}

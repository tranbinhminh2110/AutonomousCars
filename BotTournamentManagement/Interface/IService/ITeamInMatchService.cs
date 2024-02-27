using BotTournamentManagement.Data.RequestModel.TeamInMatchModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.Interface.IService
{
    public interface ITeamInMatchService
    {
        //List<TeamInMatchResponseModel> GetTeamInAMatch(string matchId);
        void AddTeamsToMatch();
        void RemoveTeamFromMatch(string teamId);
        void UpdateFinalResult(TeamInMatchUpdateModel teamInMatchUpdateModel);
    }
}

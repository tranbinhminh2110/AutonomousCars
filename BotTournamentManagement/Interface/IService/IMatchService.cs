using BotTournamentManagement.Data.RequestModel.MatchModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface IMatchService
    {
        List<MatchResponseModel> GetAllMatches();
        void CreateNewMatch(MatchCreatedModel matchCreatedModel);
        void UpdateMatch(string id, MatchUpdateModel matchUpdateModel);
        void DeleteMatch(string id);
        MatchResponseModel GetMatchById(string id);
    }
}

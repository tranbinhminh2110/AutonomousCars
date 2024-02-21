using BotTournamentManagement.Data.RequestModel.RoundModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface IRoundService
    {
        List<RoundResponseModel> getAllRoundList();
        void AddNewRound(RoundCreatedModel roundCreatedModel);
        void UpdateRound(string id, [FromForm] RoundUpdateModel roundUpdateModel);
        void DeleteRound(string  id);
        RoundResponseModel getRoundById(string id);
    }
}

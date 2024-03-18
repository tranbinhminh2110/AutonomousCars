using BotTournamentManagement.Data.RequestModel.RoundModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.Interface.IService
{
    public interface IRoundService
    {
        List<RoundResponseModel> getAllRoundList();
        void AddNewRound(RoundCreatedModel roundCreatedModel);
        void UpdateRound(string id, RoundUpdateModel roundUpdateModel);
        void DeleteRound(string  id);
        RoundResponseModel getRoundById(string id);
    }
}

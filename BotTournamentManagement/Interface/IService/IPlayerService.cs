using BotTournamentManagement.Data.RequestModel.ActivityModel;
using BotTournamentManagement.Data.RequestModel.PlayModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface IPlayerService
    {
        List<PlayerResponseModel> GetAllPlayers();
        void CreateNewPlayer(PlayerCreatedModel playerCreatedModel);
        void UpdatePlayer(string id, PlayerUpdatedModel playerUpdateModel);
        void DeletePlayer(string id);
        List<PlayerResponseModel> GetPlayerByTeamId(string teamId);
        PlayerResponseModel GetPlayerById(string id);
    }
}

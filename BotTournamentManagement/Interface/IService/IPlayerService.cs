using BotTournamentManagement.Data.RequestModel.PlayModel;
using BotTournamentManagement.Data.ResponseModel;

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

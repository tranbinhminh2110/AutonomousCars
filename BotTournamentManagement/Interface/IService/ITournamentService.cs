using BotTournamentManagement.Data.RequestModel.TournamentModel;
using BotTournamentManagement.Data.ResponseModel;

namespace BotTournamentManagement.Interface.IService
{
    public interface ITournamentService
    {
        List<TournamentResponseModel> GetAllTournament();
        void CreateNewTournament(TournamentCreatedModel tournamentCreatedModel);
        void UpdateTournament(string id, TournamentUpdateModel tournamentUpdateModel);
        void DeleteTournament(string id);
        TournamentResponseModel GetTournamentById(string id);
    }
}

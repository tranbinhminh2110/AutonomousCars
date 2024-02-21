using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.TournamentModel;
using BotTournamentManagement.Data.ResponseModel;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Interface.IService
{
    public interface ITournamentService
    {
        List<TournamentResponseModel> GetAllTournament();
        void CreateNewTournament(TournamentCreatedModel tournamentCreatedModel);
        void UpdateTournament(string id, [FromForm] TournamentUpdateModel tournamentUpdateModel);
        void DeleteTournament(string id);
        TournamentResponseModel GetTournamentById(string id);
    }
}

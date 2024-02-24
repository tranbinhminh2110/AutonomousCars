using BotTournamentManagement.Data.RequestModel.TeamInMatchModel;
using BotTournamentManagement.Data.RequestModel.TeamModel;

namespace BotTournamentManagement.Data.RequestModel.MatchModel
{
    public class MatchandTeamUpdateModel
    {
        public MatchUpdateModel MatchUpdateModel { get; set; }
        public List<TeamInMatchUpdateModel> TeamInMatchUpdateModels { get; set; }
    }
}

using BotTournamentManagement.Data.RequestModel.TeamInMatchModel;
using BotTournamentManagement.Data.RequestModel.TeamModel;

namespace BotTournamentManagement.Data.RequestModel.MatchModel
{
    public class MatchandTeamCreatedModel
    {
        public MatchCreatedModel MatchCreatedModel { get; set; }
        public List<TeamInMatchCreatedModel> TeamInMatchCreatedModel { get; set; }
    }
}

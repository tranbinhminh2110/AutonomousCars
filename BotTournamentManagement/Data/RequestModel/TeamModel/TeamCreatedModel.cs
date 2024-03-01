using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.PlayModel;

namespace BotTournamentManagement.Data.RequestModel.TeamModel
{
    public class TeamCreatedModel
    {
        public string KeyId { get; set; }
        public string TeamName { get; set; }
        public string HighSchoolId { get; set; }
        public List<PlayerCreateModelWithTeam> PlayerCreatedModels { get; set; }

    }
}

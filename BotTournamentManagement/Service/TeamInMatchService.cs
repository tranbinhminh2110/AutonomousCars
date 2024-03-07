using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.TeamInMatchModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;

namespace BotTournamentManagement.Service
{
    public class TeamInMatchService : ITeamInMatchService
    {
        private readonly ITeamInMatchRepository _teamInMatchRepository;
        private readonly IMapper _mapper;
        private readonly ITeamRepository _teamRepository;
        private readonly IMatchRepository _matchRepository;
        public TeamInMatchService(ITeamInMatchRepository teamInMatchRepository, IMapper mapper, ITeamRepository teamRepository, IMatchRepository matchRepository)
        {
            _mapper = mapper;
            _teamInMatchRepository = teamInMatchRepository;
            _teamRepository = teamRepository;
            _matchRepository = matchRepository;
        }
        public void AddTeamToMatch(TeamInMatchCreatedModel teamInMatchCreatedModel)
        {
            var matchEntity = _matchRepository.GetById(teamInMatchCreatedModel.MatchId);
            if (matchEntity is null)
            {
                throw new Exception("This match is not existed");
            }
            var teamEntity = _teamRepository.GetById(teamInMatchCreatedModel.TeamId);
            if (teamEntity is null)
            {
                throw new Exception("This team is not existed");
            }
            var teamInMatchEntity = new TeamInMatchEntity();
            teamInMatchEntity.MatchId = matchEntity.Id;
            teamInMatchEntity.TeamId = teamEntity.Id;
            _teamInMatchRepository.Add(teamInMatchEntity);
        }

        public List<TeamInMatchResponseModel> GetTeamInAMatch(string matchId)
        {
            var listTeamInMatch = _teamInMatchRepository.GetAll().OrderBy(x=>x.CreatedTime).Where(p => p.MatchId.Equals(matchId)).ToList();
            if (!listTeamInMatch.Any())
            {
                throw new Exception("Empty Team in this match");
            }
            var listTeamInMatchResponse = _mapper.Map<List<TeamInMatchResponseModel>>(listTeamInMatch);
            foreach (var teamInMatch in listTeamInMatchResponse)
            {
                var matchEntity = _matchRepository.GetById(teamInMatch.MatchId);
                teamInMatch.MatchKeyId = matchEntity.KeyId;
                var teamEntity = _teamRepository.GetById(teamInMatch.TeamId);
                teamInMatch.TeamName = teamEntity.TeamName;
            }
            
            return listTeamInMatchResponse;

        }

        public void RemoveTeamFromMatch(string teamId, string matchId)
        {
            var teamInMatch = _teamInMatchRepository.GetAll().Where(p => p.TeamId.Equals(teamId) && p.MatchId.Equals(matchId)).FirstOrDefault();
            if (teamInMatch is null)
            {
                throw new Exception("This team or match didn't existed");
            }
            else
            {
                _teamInMatchRepository.Delete(teamInMatch);
            }
        }

        public void UpdateFinalResult(string id, TeamInMatchUpdateModel teamInMatchUpdateModel)
        {
            var teamInMatch = _teamInMatchRepository.GetAll().Where(p => p.Id.Equals(id)).FirstOrDefault();
            if (teamInMatch is null)
            {
                throw new Exception("This team doesn't exist in match");
            }
            _mapper.Map(teamInMatchUpdateModel, teamInMatch);
            teamInMatch.Duration = TimeSpan.Parse(teamInMatchUpdateModel.Duration);
            _teamInMatchRepository.Update(teamInMatch);
        }
    }
}

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
        public void AddTeamToMatch(string matchId, TeamInMatchCreatedModel teamInMatchCreatedModel)
        {
            var matchEntity = _matchRepository.GetById(matchId);
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
            var listTeamInMatch = _teamInMatchRepository.GetAll().Where(p => p.MatchId.Equals(matchId)).ToList();
            if (!listTeamInMatch.Any())
            {
                throw new Exception("Empty Team in this match");
            }
            var listTeamInMatchResponse = new List<TeamInMatchResponseModel>();
            foreach (var team in listTeamInMatch)
            {
                var teamEntity = _teamRepository.GetById(team.TeamId);
                var teamResponseModel = _mapper.Map<TeamResponseModelWithoutPlayer>(teamEntity);
                TeamInMatchResponseModel responseModel = _mapper.Map<TeamInMatchResponseModel>(team);
                responseModel.teamResponse = teamResponseModel;
                listTeamInMatchResponse.Add(responseModel);
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

        public void UpdateFinalResult(string teamId, string matchId, TeamInMatchUpdateModel teamInMatchUpdateModel)
        {
            var teamInMatch = _teamInMatchRepository.GetAll().Where(p => p.MatchId.Equals(matchId) && p.TeamId.Equals(teamId)).FirstOrDefault();
            if (teamInMatch is null) 
            {
                throw new Exception("This team or match doesn't exist");
            }
            _mapper.Map(teamInMatchUpdateModel,teamInMatch);
            teamInMatch.Duration = TimeSpan.Parse(teamInMatchUpdateModel.Duration);
            _teamInMatchRepository.Update(teamInMatch);
        }
    }
}

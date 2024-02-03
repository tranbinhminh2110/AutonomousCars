using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BotTournamentManagement.Service
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;
        private readonly IMapper _mapper;

        public TeamService(ITeamRepository teamRepository, IMapper mapper)
        {
            _teamRepository = teamRepository;
            _mapper = mapper;
        }

        public void CreateANewTeam(TeamCreatedModel teamCreatedModel)
        {
            var teamList = _teamRepository.GetAll();
            foreach (TeamEntity team in teamList)
            {
                if (team.KeyId.Equals(teamCreatedModel.KeyId))
                {
                    throw new Exception("This team Id is existed !");
                }
            }
            var teamEntity = _mapper.Map<TeamEntity>(teamCreatedModel);
            _teamRepository.Add(teamEntity);
        }

        public void DeleteATeam(string id)
        {
            var chosenTeam = _teamRepository.GetById(id);
            if (chosenTeam is null)
            {
                throw new Exception("This team is not existed");
            }
            else
            {
                _teamRepository.Delete(chosenTeam);
            }
        }

        public List<TeamResponseModel> GetAllTeams()
        {
            var teamList = _teamRepository.GetAll();
            if (!teamList.Any())
            {
                throw new Exception("This team list is empty");
            }
            var responseTeamList = _mapper.Map<List<TeamResponseModel>>(teamList);
            return responseTeamList;
        }

        public void UpdateANewTeam(string id, [FromForm] TeamUpdateModel teamUpdateModel)
        {
            var chosenTeam = _teamRepository.GetById(id);
            if (chosenTeam is null)
            {
                throw new Exception("This team is not existed");
            }
            var teamList = _teamRepository.GetAll();
            foreach (var team in teamList)
            {
                if (team.KeyId.Equals(teamUpdateModel.KeyId))
                {
                    throw new Exception("This team ID existed");
                }
            }
            _mapper.Map(teamUpdateModel, chosenTeam);
            _teamRepository.Update(chosenTeam);
        }

        TeamResponseModel ITeamService.GetTeamById(string id)
        {
            var chosenTeam = _teamRepository.GetById(id);
            if (chosenTeam is null)
            {
                throw new Exception("This team is not existed");
            }
            var responseTeam = _mapper.Map<TeamResponseModel>(chosenTeam);
            return responseTeam;
        }
    }
}

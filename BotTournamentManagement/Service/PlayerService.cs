using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel.PlayModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;

namespace BotTournamentManagement.Service
{
    public class PlayerService : IPlayerService
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IMapper _mapper;
        
        public PlayerService(IPlayerRepository playerRepository, IMapper mapper) 
        {
            _playerRepository = playerRepository;
            _mapper = mapper;
        }
        public void CreateNewPlayer(PlayerCreatedModel playerCreatedModel)
        {
            var existingPlayer = _playerRepository.GetAll().Where(p => p.KeyId.Equals(playerCreatedModel.KeyId)).FirstOrDefault();
            if (existingPlayer is not null)
            {
                throw new Exception("This player is existed");
            }
            var newPlayer = _mapper.Map<PlayerEntity>(playerCreatedModel);
            _playerRepository.Add(newPlayer);
        }

        public void DeletePlayer(string id)
        {
            var chosenPlayer = _playerRepository.GetById(id);
            if (chosenPlayer is null)
            {
                throw new Exception("This player doesn't exited");
            }
            _playerRepository.Delete(chosenPlayer);
        }

        public List<PlayerResponseModel> GetAllPlayers()
        {
            var playerList = _playerRepository.GetAll().ToList();
            if (playerList is null)
            {
                throw new Exception("No users existed !");
            }
            var responsePlayerList = _mapper.Map<List<PlayerResponseModel>>(playerList);
            return responsePlayerList;
        }

        public PlayerResponseModel GetPlayerById(string id)
        {
            var chosenPlayer = _playerRepository.GetById(id);
            if (chosenPlayer is null)
            {
                throw new Exception("No existed player");
            }
            var responsePlayer = _mapper.Map<PlayerResponseModel>(chosenPlayer);
            return responsePlayer;
        }

        public List<PlayerResponseModel> GetPlayerByTeamId(string teamId)
        {
            var playerList = _playerRepository.GetAll().Where(p => p.TeamId.Equals(teamId)).ToList();
            if (playerList is null)
            {
                throw new Exception("Empty list player in this team!");
            }
            var responsePlayerList = _mapper.Map<List<PlayerResponseModel>>(playerList);
            return responsePlayerList;
        }

        public void UpdatePlayer(string id, PlayerUpdatedModel playerUpdateModel)
        {
            var chosenPlayer = _playerRepository.GetById(id);
            if (chosenPlayer is null) {
                throw new Exception("Player is not existed");
            }
            var existingPlayer = _playerRepository.GetAll().Where(p => p.KeyId.Equals(playerUpdateModel.KeyId) && !p.KeyId.Equals(chosenPlayer.KeyId)).FirstOrDefault();
            if (existingPlayer is not null)
            {
                throw new Exception("This player Id is existed");
            }
            _mapper.Map(playerUpdateModel, chosenPlayer);
            _playerRepository.Update(chosenPlayer);
        }
    }
}

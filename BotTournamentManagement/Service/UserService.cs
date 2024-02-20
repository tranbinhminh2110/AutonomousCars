using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Data.ResponseModel;
using BotTournamentManagement.Interface.IRepository;
using BotTournamentManagement.Interface.IService;
using BotTournamentManagement.Repository;

namespace BotTournamentManagement.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        public UserService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public void AddNewUser(UserRequestModel userRequestModel)
        {
            var existingUser = _userRepository.GetAll().Where(p => p.UserName == userRequestModel.UserName);
            if (existingUser.Any()) 
            {
                throw new Exception("This username is already existed");
            }
            var newUser = new UserEntity();
            if (userRequestModel.Role == Data.Enum.Role.Organizer) {
                var existingAdmins = _userRepository.GetAll().Where(p => p.KeyId.Contains("AD"));  
                newUser.KeyId = "AD" + existingAdmins.ToList().Count();
            }
            newUser = _mapper.Map<UserEntity>(userRequestModel);
            _userRepository.Add(newUser);
        }

        public void DeleteUser(string id)
        {
            var chosenUser = _userRepository.GetById(id);
            if (chosenUser is null)
            {
                throw new Exception("This user is not existed");
            }
            else 
            {
                _userRepository.Delete(chosenUser);
            }
        }

        public UserResponseModel GetUserById(string id)
        {
            var chosenUser = _userRepository.GetById(id);
            if (chosenUser is null)
            {
                throw new Exception("This user is not existed");
            }
            var responseUser = _mapper.Map<UserResponseModel>(chosenUser);
            return responseUser;
        }

        public List<UserResponseModel> GetUsersList()
        {
            var userList = _userRepository.GetAll();
            if (!userList.Any())
            {
                throw new Exception("This list is empty");
            }
            var responseUserList = _mapper.Map<List<UserResponseModel>>(userList);
            return responseUserList;
        }

        public List<UserResponseModel> SearchUser(string searchkey)
        {
            var userList = _userRepository.GetAll().Where(p => p.UserName.Contains(searchkey) || p.UserEmail.Contains(searchkey));
            if (userList is null)
            {
                throw new Exception("No user existed");
            }
            var responseUserList = _mapper.Map<List<UserResponseModel>>(userList);
            return responseUserList;
        }

        public void UpdateUser(string id, UserRequestModel userRequestModel)
        {
            var existingUser = _userRepository.GetById(id);
            if (existingUser is null)
            {
                throw new Exception("This user is not existed");
            }
            var userList = _userRepository.GetAll();
            foreach (var user in userList)
            {
                if (userRequestModel.UserName.Equals(user.UserName))
                {
                    throw new Exception("This Username is existed");
                }
            }
            _mapper.Map(userRequestModel, existingUser);
            _userRepository.Update(existingUser);
        }
    }
}

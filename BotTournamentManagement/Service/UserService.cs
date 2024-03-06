using AutoMapper;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.Enum;
using BotTournamentManagement.Data.RequestModel.UserModel;
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
            var existingUser = _userRepository.GetAll().Where(p => p.UserName == userRequestModel.UserName || p.UserEmail == userRequestModel.UserEmail).FirstOrDefault();
            if (existingUser is not null) 
            {
                throw new Exception("This username is already existed");
            }   
            var newUser = _mapper.Map<UserEntity>(userRequestModel);
            var userList = _userRepository.GetBothActiveandInactive().ToList();
            newUser.KeyId = "USER" + (userList.Count + 1).ToString();
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
            var userList = _userRepository.GetAll().ToList();
            if (!userList.Any())
            {
                throw new Exception("This list is empty.");
            }
            var responseUserList = _mapper.Map<List<UserResponseModel>>(userList);
            return responseUserList;
        }

        public List<UserResponseModel> SearchUser(string searchkey)
        {
            var userList = _userRepository.GetAll().Where(p => p.UserName.Contains(searchkey) || p.UserEmail.Contains(searchkey)).ToList();
            if (!userList.Any())
            {
                throw new Exception("No user existed.");
            }
            var responseUserList = _mapper.Map<List<UserResponseModel>>(userList);
            return responseUserList;
        }

        public void UpdateUser(string Id, UserRequestModel userRequestModel)
        {
            var existingUser = _userRepository.GetById(Id);
            if (existingUser is null)
            {
                throw new Exception("This user is not existed.");
            }
            var userList = _userRepository.GetAll();
            foreach (var user in userList)
            {
                if (user.UserName.Equals(userRequestModel.UserName) && !user.UserName.Equals(existingUser.UserName))
                {
                    throw new Exception("This Username is existed.");
                }
                if (user.UserEmail.Equals(userRequestModel.UserEmail) && !user.UserEmail.Equals(existingUser.UserEmail))
                {
                    throw new Exception("This email is already used.");
                }
            }
            _mapper.Map(userRequestModel, existingUser);
            _userRepository.Update(existingUser);
        }
    }
}

using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data.RequestModel;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }

        public UserEntity GetUser(RequestLoginModel requestLoginModel)
        {
            var user = GetAll().Where(u => u.UserName.Equals(requestLoginModel.UserName) && u.Password.Equals(requestLoginModel.Password)).FirstOrDefault();
            return user;
        }
        
    }
}

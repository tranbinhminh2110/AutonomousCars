using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class UserRepository : BaseRepository<UserEntity>, IUserRepository
    {
        public UserRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
        
    }
}

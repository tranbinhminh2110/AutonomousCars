using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Data;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class PlayerRepository : BaseRepository<PlayerEntity>, IPlayerRepository
    {
        public PlayerRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}

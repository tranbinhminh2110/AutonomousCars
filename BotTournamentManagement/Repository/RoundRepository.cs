using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class RoundRepository : BaseRepository<RoundEntity>, IRoundRepository
    {
        public RoundRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

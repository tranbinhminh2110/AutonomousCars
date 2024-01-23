using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class MapRepository : BaseRepository<MapEntity>, IMapRepository
    {
        public MapRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

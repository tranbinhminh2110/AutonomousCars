using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class ActivityTypeRepository : BaseRepository<ActivityTypeEntity>, IActivityTypeRepository
    {
        public ActivityTypeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}

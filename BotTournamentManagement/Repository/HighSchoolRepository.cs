using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class HighSchoolRepository : BaseRepository<HighSchoolEntity>, IHighschoolRepository
    {
        public HighSchoolRepository(AppDbContext appDbContext) : base(appDbContext)
        {

        }
    }
}

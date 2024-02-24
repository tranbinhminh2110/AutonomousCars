using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities;
using BotTournamentManagement.Interface.IRepository;

namespace BotTournamentManagement.Repository
{
    public class RefreshTokenRepository : IRefreshTokenRepository
    {
        private readonly AppDbContext _appDbContext;

        public RefreshTokenRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(RefreshToken refreshToken)
        {
            try
            {
                _appDbContext.RefreshTokens.Add(refreshToken);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<RefreshToken> GetRefreshTokens()
        {
            return _appDbContext.RefreshTokens.ToList();
        }

    }
}

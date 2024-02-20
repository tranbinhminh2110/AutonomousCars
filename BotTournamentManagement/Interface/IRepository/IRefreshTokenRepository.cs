using BotTournamentManagement.Data.Entities;

namespace BotTournamentManagement.Interface.IRepository
{
    public interface IRefreshTokenRepository
    {
        List<RefreshToken> GetRefreshTokens();
        void Add(RefreshToken refreshToken);
    }
}

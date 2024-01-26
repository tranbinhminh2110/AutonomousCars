using BotTournamentManagement.Data.Entities.Base;

namespace BotTournamentManagement.Interface.IRepository
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetById(string id);
    }
}

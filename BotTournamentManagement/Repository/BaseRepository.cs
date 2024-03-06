using BotTournamentManagement.Data;
using BotTournamentManagement.Data.Entities.Base;
using BotTournamentManagement.Interface.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BotTournamentManagement.Repository
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _appDbContext;
        public BaseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public void Add(T entity)
        {
            try
            {
                _appDbContext.Set<T>().Add(entity);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error adding entity: {ex.Message}", ex);
            }
        }

        public void Delete(T entity)
        {
            try
            {
                entity.DeletedTime = DateTime.Now;
                _appDbContext.Set<T>().Update(entity);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error deleting entity: {ex.Message}", ex);
            }
        }

        public IQueryable<T> GetAll()
        {
            try
            {
                return _appDbContext.Set<T>().Where(p=>p.DeletedTime == null);
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
        public IQueryable<T> GetBothActiveandInactive()
        {
            try
            {
                return _appDbContext.Set<T>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }

        public T GetById(string id)
        {
            try 
            {
                return _appDbContext.Set<T>().Where(p => p.Id.Equals(id) && p.DeletedTime == null).FirstOrDefault();
            }
            catch (Exception ex) 
            {
                throw new Exception($"Error getting entity: {ex.Message}", ex);
            }
        }
        public void Update(T entity)
        {
            try
            {
                entity.LastUpdatedTime = DateTimeOffset.Now;
                _appDbContext.Set<T>().Update(entity);
                _appDbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error updating entity: {ex.Message}", ex);
            }
        }
    }
}

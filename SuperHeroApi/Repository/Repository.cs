using Microsoft.EntityFrameworkCore;
using SuperHeroApi.Data;

namespace SuperHeroApi.Repository
{
    public class Repository<TEntity> : IDisposable, IRepository<TEntity> where TEntity : class
    {
        protected readonly DataContext _dataContext;

        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _dataContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _dataContext.Set<TEntity>().FindAsync(id);
        }

        public IQueryable<TEntity> GetQueryable()
        {
            return _dataContext.Set<TEntity>();     
        }

        public void Insert(TEntity entity)
        {
            _dataContext.Set<TEntity>().Add(entity);
        }
  
        public void Update(TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            _dataContext.Set<TEntity>().Remove(entity);
        }

        public Task SaveChangesAsync()
        {
            return _dataContext.SaveChangesAsync();
        }
        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}

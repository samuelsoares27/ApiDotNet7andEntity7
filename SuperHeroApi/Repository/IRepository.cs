namespace SuperHeroApi.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<List<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        IQueryable<TEntity> GetQueryable();
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task SaveChangesAsync();
    }
}

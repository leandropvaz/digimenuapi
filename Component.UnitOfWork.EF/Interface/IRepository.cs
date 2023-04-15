namespace Component.UnitOfWork.EF.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        #region Métodos Asyncronos
        IEnumerable<TEntity> GetAll();
        TEntity GetById(int id);
        TEntity GetById(Guid id);
        void Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        void Update(TEntity entity);
        void UpdateRange(IEnumerable<TEntity> entities);
        void Remove(TEntity entity);
        void RemoveRange(IEnumerable<TEntity> entities);
        int GetTotal();
        #endregion

        #region Métodos Syncronos
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(int id);
        Task<TEntity> GetByIdAsync(Guid id);
        Task AddAsync(TEntity entity);
        Task AddRangeAsync(IEnumerable<TEntity> entities);
        Task<int> GetTotalAsync();
        #endregion
    }
}

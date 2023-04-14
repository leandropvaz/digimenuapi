using Component.UnitOfWork.EF.Interface;
using Microsoft.EntityFrameworkCore;

namespace Component.UnitOfWork.EF
{
#nullable disable
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly DbContext _dbContext;
        private readonly DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<TEntity>();
        }

        #region Métodos Syncronos
        public IEnumerable<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public TEntity GetById(Guid id)
        {
            return _dbSet.Find(id);
        }

        public void Add(TEntity entity)
        {
            _dbSet.Add(entity);
            //_dbContext.SaveChanges();
        }

        public void AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRange(entities);
            //_dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
           
            var primaryKey = _dbContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties.FirstOrDefault();
            var primaryKeyValue = primaryKey.PropertyInfo.GetValue(entity);

            var existingEntity = _dbSet.Local.FirstOrDefault(e => primaryKey.PropertyInfo.GetValue(e).Equals(primaryKeyValue));

            if (existingEntity != null)
            {
                _dbSet.Entry(existingEntity).CurrentValues.SetValues(entity);
            }
            else
            {
                _dbSet.Attach(entity);
                _dbSet.Entry(entity).State = EntityState.Modified;
            }
        }

        public void UpdateRange(IEnumerable<TEntity> entities)
        {
            foreach (var item in entities)
            {
                this.Update(item);
            }
        }


        public void Remove(TEntity entity)
        {
            _dbSet.Remove(entity);
            //_dbContext.SaveChanges();
        }

        public void RemoveById(int id)
        {
            var e = _dbSet.Find(id);
            if (e != null)
                this.Remove(e);
        }

        public void RemoveById(Guid id)
        {
            var e = _dbSet.Find(id);
            if (e != null)
                this.Remove(e);
        }

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbSet.RemoveRange(entities);
            //_dbContext.SaveChanges();
        }
        public int GetTotal()
        {
            return _dbSet.Count();
        }
        #endregion

        #region Métodos Asyncronos
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            //await _dbContext.SaveChangesAsync();
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            //await _dbContext.SaveChangesAsync();
        }

        public virtual async Task<int> GetTotalAsync()
        {
            return await _dbSet.CountAsync();
        }

        #endregion

    }

}

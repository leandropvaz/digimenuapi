using Microsoft.EntityFrameworkCore;

namespace Component.UnitOfWork.EF.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext GetContext();
        void SetContext(DbContext dbContext);
        IRepository<TEntity> GetRepository<TEntity>() where TEntity : class;
        int SaveChanges();
        Task<int> SaveChangesAsync();
        void BeginTransaction();
        void Commit();
        void Rollback();
        Task<int> ExecuteProcedure<T>(string nameProcedure, T entity, string? schemaDataTableType = null);
        Task<TOutput> ExecuteProcedureWithOutput<T, TOutput>(string nameProcedure, T entity, string schemaDataTableType = null);
        Task<List<TResult>> ExecuteProcedureWithReturn<T, TResult>(string nameProcedure, T entity, string schemaDataTableType = null) where TResult : new();
    }
}

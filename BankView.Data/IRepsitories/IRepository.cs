using System.Linq.Expressions;

namespace BankView.Data.IRepsitories
{
    public interface IRepository<TEntity>
    {
        public ValueTask<TEntity> InsertAsync(TEntity entity);
        public ValueTask<TEntity> UpdateAsync(TEntity entity);
        public ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression);
        public ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression);
        public IQueryable<TEntity> SelectAll();
        public ValueTask SaveChangesAsync();

    }
}

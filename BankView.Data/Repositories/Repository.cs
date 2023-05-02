using BankView.Data.Contexts;
using BankView.Data.IRepsitories;
using BankView.Domain.Commons;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BankView.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Auditable
    {
        private readonly AppDbContext dbContext;
        private readonly DbSet<TEntity> dbSet;
        public Repository(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
            this.dbSet = dbContext.Set<TEntity>();
        }


        public async ValueTask<bool> DeleteAsync(Expression<Func<TEntity, bool>> expression)
        {
            var entity = await this.dbSet.FirstOrDefaultAsync(expression);

            if (entity is not null)
            {
                this.dbSet.Remove(entity);
                return true;
            }
            return false;
        }

        public async ValueTask<TEntity> InsertAsync(TEntity entity)
            => (await this.dbSet.AddAsync(entity)).Entity;

        public IQueryable<TEntity> SelectAll()
             => this.dbSet;

        public async ValueTask<TEntity> SelectAsync(Expression<Func<TEntity, bool>> expression)
            => await this.dbSet.FirstOrDefaultAsync(expression);

        public async ValueTask<TEntity> UpdateAsync(TEntity entity)
        {
            var entry = this.dbSet.Update(entity);
            return await Task.FromResult(entry.Entity);
        }

        public async ValueTask SaveChangesAsync()
            => await this.dbContext.SaveChangesAsync();
    }
}

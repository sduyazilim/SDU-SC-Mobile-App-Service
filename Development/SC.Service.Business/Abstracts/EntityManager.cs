using SC.Service.Data.Model;
using SC.Service.Data.Model.Contracts;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Collections.Generic;

namespace SC.Service.Business.Abstracts
{
    public abstract class EntityManager<TEntity> : IDisposable
        where TEntity : class,IEntity<int>
    {
        private bool disposed = false;

        protected EFContext Context { get; private set; }
        protected abstract Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> Sorting { get; }

        public EntityManager()
            : this(new EFContext())
        {
        }

        public EntityManager(EFContext context)
        {
            this.Context = context;
        }

        public async Task<IEnumerable<TEntity>> GetEntitiesAsync(int skip, int take)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();

            if (Sorting != null)
            {
                queryable = Sorting(queryable);
            }

            return await queryable.Skip(skip).Take(take).ToArrayAsync();
        }

        public async Task<TEntity> GetEntityAsync(int id)
        {
            return await Context.Set<TEntity>().SingleOrDefaultAsync(q => q.Id == id);
        }

        public async Task<int> GetCountAsync()
        {
            return await Context.Set<TEntity>().CountAsync();
        }

        public async Task CreateEntityAsync(TEntity entity)
        {
            EntityState originalState = EntityState.Detached;

            try
            {
                originalState = Context.Entry<TEntity>(entity).State;
                Context.Entry<TEntity>(entity).State = EntityState.Added;

                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occured while creating the entity.", e);
            }
            finally
            {
                Context.Entry<TEntity>(entity).State = originalState;
            }
        }

        public async Task UpdateEntityAsync(TEntity entity)
        {
            EntityState originalState = EntityState.Detached;

            try
            {
                originalState = Context.Entry<TEntity>(entity).State;
                Context.Entry<TEntity>(entity).State = EntityState.Modified;

                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occured while updating the entity.", e);
            }
            finally
            {
                Context.Entry<TEntity>(entity).State = originalState;
            }
        }

        public async Task DeleteEntityAsync(int id)
        {
            TEntity entity = await GetEntityAsync(id);
            EntityState originalState = EntityState.Detached;

            try
            {
                originalState = Context.Entry<TEntity>(entity).State;
                Context.Entry<TEntity>(entity).State = EntityState.Deleted;

                await Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw new Exception("An error occured while deleting the entity.", e);
            }
            finally
            {
                Context.Entry<TEntity>(entity).State = originalState;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.Context.Dispose();
                }

                disposed = true;
            }
        }
    }
}

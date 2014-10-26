using SC.Service.Contract.Commons;
using SC.Service.Data.Model.Contracts;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Data.Entity;
using SC.Service.Core.Exceptions;

namespace SC.Service.Business.Abstracts
{
    public abstract class DTOManager<TEntity, TListingDto, TDetailDto> : EntityManager<TEntity>
        where TEntity : class,IEntity<int>
    {
        protected abstract Expression<Func<TEntity, TListingDto>> EntityToListingDtoMapping { get; }
        protected abstract Expression<Func<TEntity, TDetailDto>> EntityToDetailDtoMapping { get; }

        public async Task<CountedCollectionContainer<TListingDto>> GetAsync(int skip, int take)
        {
            IQueryable<TEntity> queryable = Context.Set<TEntity>();

            if (Sorting != null)
            {
                queryable = Sorting(queryable);
            }

            CountedCollectionContainer<TListingDto> retVal = new CountedCollectionContainer<TListingDto>(
                await queryable.Select(EntityToListingDtoMapping).Skip(skip).Take(take).ToListAsync(),
                await queryable.CountAsync()
                );

            if (retVal.Content == null || retVal.Content.Count() == 0)
            {
                throw new ServiceException(System.Net.HttpStatusCode.NotFound, "No records has been found.");
            }

            return retVal;
        }

        public async Task<TDetailDto> GetAsync(int id)
        {
            TDetailDto retVal = await Context.Set<TEntity>().Where(e => e.Id == id).Select(EntityToDetailDtoMapping).SingleOrDefaultAsync();

            if (retVal == null)
            {
                throw new ServiceException(System.Net.HttpStatusCode.NotFound, "No record has been found for given ID.");
            }

            return retVal;
        }
    }
}

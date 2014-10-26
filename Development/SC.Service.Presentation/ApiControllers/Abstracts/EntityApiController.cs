using SC.Service.Business.Abstracts;
using SC.Service.Contract.Commons;
using SC.Service.Data.Model.Contracts;
using System.Threading.Tasks;
using System.Web.Http;

namespace SC.Service.Presentation.ApiControllers.Abstracts
{
    public abstract class EntityApiController<TEntity, TListingDto, TDetailDto> : ApiController
        where TEntity : class,IEntity<int>
    {
        protected abstract DTOManager<TEntity, TListingDto, TDetailDto> Manager { get; }

        public async Task<CountedCollectionContainer<TListingDto>> Get(int skip, int take)
        {
            return await Manager.GetAsync(skip, take);
        }

        public async Task<TDetailDto> Get(int id)
        {
            return await Manager.GetAsync(id);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                Manager.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}
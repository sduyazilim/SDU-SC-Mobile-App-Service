using System.Threading.Tasks;
using System.Web.Mvc;
using SC.Service.Data.Model.Contracts;
using SC.Service.Presentation.Models;
using SC.Service.Core;
using SC.Service.Business.Abstracts;

namespace SC.Service.Presentation.Controllers.Abstracts
{
    public abstract class EntityController<TEntity> : Controller
        where TEntity : class, IEntity<int>
    {
        protected abstract EntityManager<TEntity> Manager { get; }

        public async Task<ActionResult> Index(int page = 1)
        {
            ListingViewModel<TEntity> model = new ListingViewModel<TEntity>
            {
                Data = await Manager.GetEntitiesAsync((page - 1) * Constants.RecordPerPage, Constants.RecordPerPage),
                Paging = new PagingModel(page, Constants.RecordPerPage, await Manager.GetCountAsync())
            };

            return View(model);
        }

        public async Task<ActionResult> AddEdit(int? id)
        {
            ActionResult retVal = View();

            if (id.HasValue)
            {
                TEntity entity = await Manager.GetEntityAsync(id.Value);

                if (entity == null)
                {
                    retVal = HttpNotFound();
                }

                retVal = View(entity);
            }

            return retVal;
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddEdit(TEntity entity)
        {
            ActionResult retVal = View(entity);

            ModelState["Id"].Errors.Clear();

            if (entity is ICreationTrackable)
            {
                ModelState["CreatedOn"].Errors.Clear();
                ModelState["CreatedBy"].Errors.Clear();
            }

            if (entity is IUpdateTrackable)
            {
                ModelState["UpdatedOn"].Errors.Clear();
                ModelState["UpdatedBy"].Errors.Clear();
            }

            if (ModelState.IsValid)
            {
                if (entity.Id > 0)
                {
                    await Manager.UpdateEntityAsync(entity);
                }
                else
                {
                    await Manager.CreateEntityAsync(entity);
                }

                retVal = RedirectToAction("Index");
            }

            return retVal;
        }

        [Authorize]
        public async Task<ActionResult> Delete(int id)
        {
            await Manager.DeleteEntityAsync(id);
            return RedirectToAction("Index");
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
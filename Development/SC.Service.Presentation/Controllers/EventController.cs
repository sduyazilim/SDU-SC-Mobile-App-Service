using SC.Service.Data.Model.Entities;
using SC.Service.Business;

namespace SC.Service.Presentation.Controllers
{
    public class EventController : Abstracts.EntityController<EventEntity>
    {
        protected override Business.Abstracts.EntityManager<EventEntity> Manager
        {
            get
            {
                return new EventManager();
            }
        }
    }
}

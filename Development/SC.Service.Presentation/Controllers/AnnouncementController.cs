using SC.Service.Business;
using SC.Service.Data.Model.Entities;

namespace SC.Service.Presentation.Controllers
{
    public class AnnouncementController : Abstracts.EntityController<AnnouncementEntity>
    {
        protected override Business.Abstracts.EntityManager<AnnouncementEntity> Manager
        {
            get 
            { 
                return new AnnouncementManager();
            }
        }
    }
}
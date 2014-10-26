using SC.Service.Business;
using SC.Service.Contract.Events;
using SC.Service.Data.Model.Entities;

namespace SC.Service.Presentation.ApiControllers
{
    public class EventController : Abstracts.EntityApiController<EventEntity, EventListingDto, EventDetailDto>
    {
        protected override Business.Abstracts.DTOManager<EventEntity, EventListingDto, EventDetailDto> Manager
        {
            get
            {
                return new EventManager();
            }
        }
    }
}

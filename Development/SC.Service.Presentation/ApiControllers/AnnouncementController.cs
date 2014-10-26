using SC.Service.Business;
using SC.Service.Contract.Announcements;
using SC.Service.Data.Model.Entities;

namespace SC.Service.Presentation.ApiControllers
{
    public class AnnouncementController : Abstracts.EntityApiController<AnnouncementEntity, AnnouncementListingDto, AnnouncementDetailDto>
    {
        protected override Business.Abstracts.DTOManager<AnnouncementEntity, AnnouncementListingDto, AnnouncementDetailDto> Manager
        {
            get
            {
                return new AnnouncementManager();
            }
        }
    }
}
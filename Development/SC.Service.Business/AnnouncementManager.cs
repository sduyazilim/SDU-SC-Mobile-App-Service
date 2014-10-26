using System;
using System.Linq;
using SC.Service.Contract.Announcements;
using SC.Service.Data.Model.Entities;
using System.Linq.Expressions;
using SC.Service.Business.Abstracts;

namespace SC.Service.Business
{
    public sealed class AnnouncementManager : DTOManager<AnnouncementEntity, AnnouncementListingDto, AnnouncementDetailDto>
    {
        protected override Func<IQueryable<AnnouncementEntity>, IOrderedQueryable<AnnouncementEntity>> Sorting
        {
            get 
            {
                return a => a.OrderByDescending(x => x.CreatedOn);
            }
        }

        protected override Expression<Func<AnnouncementEntity, AnnouncementListingDto>> EntityToListingDtoMapping
        {
            get 
            {
                return a => new AnnouncementListingDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Summary = a.Summary
                };
            }
        }

        protected override Expression<Func<AnnouncementEntity, AnnouncementDetailDto>> EntityToDetailDtoMapping
        {
            get
            {
                return a => new AnnouncementDetailDto
                {
                    Id = a.Id,
                    Title = a.Title,
                    Summary = a.Summary,

                    Details = a.Details,
                    CreatedOn = a.CreatedOn
                };
            }
        }
    }
}

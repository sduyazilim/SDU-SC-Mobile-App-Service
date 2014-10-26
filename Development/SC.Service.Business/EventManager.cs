using System;
using System.Linq;
using System.Linq.Expressions;
using SC.Service.Data.Model.Entities;
using SC.Service.Contract.Events;
using SC.Service.Business.Abstracts;

namespace SC.Service.Business
{
    public sealed class EventManager : DTOManager<EventEntity, EventListingDto, EventDetailDto>
    {
        protected override Func<IQueryable<EventEntity>, IOrderedQueryable<EventEntity>> Sorting
        {
            get
            { 
                return e => e.OrderByDescending(x => x.EndDate);
            }
        }

        protected override Expression<Func<EventEntity, EventListingDto>> EntityToListingDtoMapping
        {
            get 
            {
                return e => new EventListingDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Location = e.Location,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate
                };
            }
        }

        protected override Expression<Func<EventEntity, EventDetailDto>> EntityToDetailDtoMapping
        {
            get
            {
                return e => new EventDetailDto
                {
                    Id = e.Id,
                    Title = e.Title,
                    Location = e.Location,
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,

                    FacebookEventId = e.FacebookEventId,
                    Details = e.Details
                };
            }
        }
    }
}

using System;

namespace SC.Service.Contract.Events
{
    public sealed class EventDetailDto : EventListingDto
    {
        public string Details { get; set; }

        public string FacebookEventId { get; set; }
    }
}

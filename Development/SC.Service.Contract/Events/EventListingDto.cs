using System;

namespace SC.Service.Contract.Events
{
    public class EventListingDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Location { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}

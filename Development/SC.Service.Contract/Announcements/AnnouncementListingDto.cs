using System;

namespace SC.Service.Contract.Announcements
{
    public class AnnouncementListingDto
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public DateTime CreatedOn { get; set; }
    }
}

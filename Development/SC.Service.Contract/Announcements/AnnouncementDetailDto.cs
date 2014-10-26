using System;

namespace SC.Service.Contract.Announcements
{
    public sealed class AnnouncementDetailDto : AnnouncementListingDto
    {
        public string Details { get; set; }
    }
}

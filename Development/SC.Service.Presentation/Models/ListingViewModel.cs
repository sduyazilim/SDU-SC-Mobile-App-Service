using System.Collections.Generic;

namespace SC.Service.Presentation.Models
{
    public class ListingViewModel<T>
    {
        public IEnumerable<T> Data { get; set; }

        public PagingModel Paging { get; set; }
    }
}
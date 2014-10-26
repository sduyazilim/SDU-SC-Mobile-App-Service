using System.Collections.Generic;

namespace SC.Service.Contract.Commons
{
    public class CountedCollectionContainer<T>
    {
        public IEnumerable<T> Content { get; private set; }

        public int TotalCount { get; private set; }

        public CountedCollectionContainer(IEnumerable<T> content, int totalCount)
        {
            this.Content = content;
            this.TotalCount = totalCount;
        }
    }
}

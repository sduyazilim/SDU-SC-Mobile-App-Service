using System;

namespace SC.Service.Presentation.Models
{
    public class PagingModel
    {
        public int CurrentPage { get; private set; }

        public int RecordPerPage { get; private set; }

        public int TotalRecord { get; private set; }

        /* That can set by only constructor */
        public int TotalPage { get; private set; }

        public PagingModel(int currentPage, int recordPerPage, int totalRecord)
        {
            this.CurrentPage = currentPage;
            this.RecordPerPage = recordPerPage;
            this.TotalRecord = totalRecord;

            this.TotalPage = Calculate();
        }

        private int Calculate()
        {
            if (TotalRecord % RecordPerPage == 0)
            {
                return TotalRecord / RecordPerPage;
            }
            else
            {
                return (TotalRecord / RecordPerPage) + 1;
            }
        }
    }
}
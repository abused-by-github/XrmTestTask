using System;

namespace DomainModel
{
    public class ResumeSearch
    {
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Header { get; set; }

        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public ResumeSearch()
        {
            PageNumber = 1;
            PageSize = 5;
        }
    }
}

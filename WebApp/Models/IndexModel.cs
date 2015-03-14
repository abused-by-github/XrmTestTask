using DomainModel;

namespace XrmTestTask.WebApp.Models
{
    public class IndexModel
    {
        public ResumeSearch SearchRequest { get; set; }
        public Page<Resume> SearchResult { get; set; }

        public string DateFrom
        {
            get { return SearchRequest.DateFrom.HasValue ? SearchRequest.DateFrom.Value.ToString("d") : null; }
        }

        public string DateTo
        {
            get { return SearchRequest.DateTo.HasValue ? SearchRequest.DateTo.Value.ToString("d") : null; }
        }

        public int TotalPages
        {
            get
            {
                var result = SearchResult.Total / SearchRequest.PageSize;
                return result == 0 ? 1 : result;
            }
        }
    }
}
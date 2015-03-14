using System;
using System.Linq;
using DomainModel;
using XrmTestTask.BusinessLogicApi;
using XrmTestTask.DataAccessApi;
using XrmTestTask.E1ClientApi;

namespace XrmTestTask.BusinessLogic
{
    public class ResumeFacade : IResumeFacade
    {
        public IResumeClient ResumeClient { get; set; }
        public IUnitOfWork UnitOfWork { get; set; }

        public void Grab()
        {
            var resumes = ResumeClient.Grab();
            var urls = resumes.Select(r => r.Url).ToList();
            var existingResumes = UnitOfWork.Resumes.Where(r => urls.Contains(r.Url)).ToList();
            foreach (var resume in resumes)
            {
                var existingResume = existingResumes.FirstOrDefault(r => r.Url == resume.Url);
                if (existingResume != null) //Update
                {
                    existingResume.Header = resume.Header;
                }
                else //Create
                {
                    UnitOfWork.Resumes.Add(resume);
                }
            }
            UnitOfWork.Commit();
        }

        public Page<Resume> Search(ResumeSearch search)
        {
            search = search ?? new ResumeSearch();

            IQueryable<Resume> query = UnitOfWork.Resumes;

            if (search.DateFrom.HasValue)
            {
                var dateFrom = search.DateFrom.Value.Date; //Beginning of the day
                query = query.Where(r => r.DateAdded >= dateFrom);
            }
            if (search.DateTo.HasValue)
            {
                var dateTo = new DateTime(search.DateTo.Value.Year,
                    search.DateTo.Value.Month,
                    search.DateTo.Value.Day,
                    23, 59, 59); //End of the day
                query = query.Where(r => r.DateAdded <= dateTo);
            }
            if (!string.IsNullOrEmpty(search.Header))
                query = query.Where(r => r.Header.Contains(search.Header));

            query = query.OrderByDescending(r => r.DateAdded);

            var result = new Page<Resume>
            {
                Items = query.Skip((search.PageNumber - 1) * search.PageSize).Take(search.PageSize).ToList(),
                Total = query.Count()
            };
            return result;
        }
    }
}

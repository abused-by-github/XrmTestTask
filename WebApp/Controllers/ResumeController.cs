using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel;
using XrmTestTask.BusinessLogicApi;
using XrmTestTask.WebApp.Models;

namespace XrmTestTask.WebApp.Controllers
{
    public class ResumeController : Controller
    {
        public IResumeFacade ResumeFacade { get; set; }

        public ActionResult Index(ResumeSearch search)
        {
            var model = new IndexModel
            {
                SearchRequest = search,
                SearchResult = ResumeFacade.Search(search)
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Grab()
        {
            ResumeFacade.Grab();
            return RedirectToAction("Index");
        }
    }
}

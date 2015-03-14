using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using WebApp;
using XrmTestTask.Container;

namespace XrmTestTask.WebApp
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private XrmTestTaskApplicationContainer _container;

        protected void Application_Start()
        {
            _container = new XrmTestTaskApplicationContainer();
            DependencyResolver.SetResolver(_container.MvcDependencyResolver);

            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}
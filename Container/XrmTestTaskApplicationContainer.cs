using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.Mvc;
using XrmTestTask.BusinessLogic;
using XrmTestTask.BusinessLogicApi;
using XrmTestTask.DataAccess;
using XrmTestTask.DataAccessApi;
using XrmTestTask.E1Client;
using XrmTestTask.E1ClientApi;

namespace XrmTestTask.Container
{
    public class XrmTestTaskApplicationContainer
    {
        private readonly IContainer _autofac;

        public readonly AutofacDependencyResolver MvcDependencyResolver;

        public XrmTestTaskApplicationContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(AppDomain.CurrentDomain.GetAssemblies())
                .InstancePerRequest()
                .PropertiesAutowired();

            builder.RegisterType<ResumeFacade>().As<IResumeFacade>()
                .PropertiesAutowired()
                .InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
               .PropertiesAutowired()
               .InstancePerLifetimeScope();

            builder.RegisterType<ResumeClient>().As<IResumeClient>()
               .PropertiesAutowired()
               .InstancePerLifetimeScope();

            _autofac = builder.Build();
            MvcDependencyResolver = new AutofacDependencyResolver(_autofac);
        }
    }
}

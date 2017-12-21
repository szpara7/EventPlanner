using EventPlanner.Common.DAL;
using EventPlanner.Common.Interfaces;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace EventPlanner.Infrastructure
{
    public class DependencyInjectionController : IDependencyResolver
    {
        private IKernel ninjectKernel;

        public DependencyInjectionController()
        {
            this.ninjectKernel = new StandardKernel();
            AddBindings();
        }


        public object GetService(Type serviceType)
        {
            return ninjectKernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return ninjectKernel.GetAll(serviceType);
        }


        /* method which register dependecy between interface and class */
        private void AddBindings() 
        {
            /* DB repository interfaces */
            ninjectKernel.Bind<IDatePreferenceRepository>().To<DatePreferenceRepository>();
            ninjectKernel.Bind<IEventRepository>().To<EventRepository>();
            ninjectKernel.Bind<IEventUserGroupRepository>().To<EventUserGroupRepository>();
            ninjectKernel.Bind<IPostRepository>().To<PostRepository>();
            ninjectKernel.Bind<IUserRepository>().To<UserRepository>();
            /* DB repository interfaces */



        }
    }

}
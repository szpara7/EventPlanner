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

        private void AddBindings()
        {

        }
    }

}
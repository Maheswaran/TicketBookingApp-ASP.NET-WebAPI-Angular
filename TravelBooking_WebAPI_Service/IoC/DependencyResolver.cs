using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace TravelBooking_WebAPI_Service.IoC
{
    public class NInjectDependencyResolver : IDependencyResolver
    {
        //private IKernel kernel;

        //public NInjectDependencyResolver() : this(new StandardKernel())
        //{
        //}

        //public NInjectDependencyResolver(IKernel ninjectKernel, bool scope = false)
        //{
        //    kernel = ninjectKernel;
        //    if (!scope)
        //    {
        //        AddBindings(kernel);
        //    }
        //}


        public IDependencyScope BeginScope()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public object GetService(Type serviceType)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            throw new NotImplementedException();
        }
    }
}
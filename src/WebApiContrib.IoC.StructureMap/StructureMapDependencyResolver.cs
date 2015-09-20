using System;
using System.Web.Http.Dependencies;
using System.Web.Http.Dispatcher;
using StructureMap;

namespace WebApiContrib.IoC.StructureMap
{
    public class StructureMapResolver : StructureMapDependencyScope, IDependencyResolver
    {
        private readonly IContainer _container;

        public StructureMapResolver(IContainer container)
            : base(container)
        {
            if (container == null)
                throw new ArgumentNullException("container");

            _container = container;
        }

        public IDependencyScope BeginScope()
        {
            return new StructureMapDependencyScope(_container.GetNestedContainer());
        }
    }
}

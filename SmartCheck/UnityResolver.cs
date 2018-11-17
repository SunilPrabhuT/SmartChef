using System;
using System.Collections.Generic;
using System.Web.Http.Dependencies;
using Unity;
using Unity.Exceptions;

namespace SmartChef
{
    /// <inheritdoc />
    /// <summary>
    /// The UnityResolver class
    /// </summary>
    public class UnityResolver : IDependencyResolver
    {
        /// <summary>
        /// The variable for container
        /// </summary>
        private readonly IUnityContainer _container;
        /// <summary>
        /// The Unity Resolver
        /// </summary>
        /// <param name="container"></param>
        public UnityResolver(IUnityContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("container");
            _container = container;
        }
        /// <summary>
        /// The Get service 
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public object GetService(Type serviceType)
        {
            try
            {
                return _container.Resolve(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return null;
            }
        }
        /// <summary>
        /// The Get Services
        /// </summary>
        /// <param name="serviceType"></param>
        /// <returns></returns>
        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return _container.ResolveAll(serviceType);
            }
            catch (ResolutionFailedException)
            {
                return new List<object>();
            }
        }
        /// <summary>
        /// The Begin scope
        /// </summary>
        /// <returns></returns>
        public IDependencyScope BeginScope()
        {
            var child = _container.CreateChildContainer();
            return new UnityResolver(child);
        }
        /// <summary>
        /// Disponses the object
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }
        /// <summary>
        /// disposes the object
        /// </summary>
        /// <param name="disposing"></param>
        protected virtual void Dispose(bool disposing)
        {
            _container.Dispose();
        }
    }
}
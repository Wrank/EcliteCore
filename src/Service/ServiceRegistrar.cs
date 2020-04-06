using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;
using System.Reflection;

namespace EcliteService
{
    public static class ServiceRegistrar
    {
        public static void RegisterEcliteServices(this ApplicationPartManager manager, IServiceCollection services)
        {
            if (manager == null)
            {
                throw new ArgumentNullException(nameof(manager));
            }

            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            var feature = new ServiceFeature();

            manager.PopulateFeature(feature);

            foreach (var scopedService in feature.ScopedServices)
            {
                RegisterScopedService(services, ServiceType(scopedService), ImplementationType(scopedService));
            }

            foreach (var transientService in feature.TransientServices)
            {
                RegisterTransientService(services, ServiceType(transientService), ImplementationType(transientService));
            }

            foreach (var singletonService in feature.SingletonServices)
            {
                RegisterSingletonService(services, ServiceType(singletonService), ImplementationType(singletonService));
            }
        }

        internal static Type ServiceType(TypeInfo typeInfo)
        {
            return typeInfo.AsType().GetImmediateInterface();
        }

        internal static Type ImplementationType(TypeInfo typeInfo)
        {
            return typeInfo.AsType();
        }
        internal static void RegisterScopedService(IServiceCollection services, Type serviceType, Type implementationType)
        {
            AddService(services, serviceType, implementationType, ServiceLifetime.Scoped);
        }

        internal static void RegisterTransientService(IServiceCollection services, Type serviceType, Type implementationType)
        {
            AddService(services, serviceType, implementationType, ServiceLifetime.Transient);
        }

        internal static void RegisterSingletonService(IServiceCollection services, Type serviceType, Type implementationType)
        {
            AddService(services, serviceType, implementationType, ServiceLifetime.Singleton);
        }

        internal static void AddService(IServiceCollection Services, Type serviceType, Type implementationType, ServiceLifetime serviceLifetime)
        {
            if(serviceType == null)
            {
                throw new ArgumentNullException(nameof(serviceType));
            }

            if(implementationType == null)
            {
                throw new ArgumentNullException(nameof(implementationType));
            }

            Services.Add(
                ServiceDescriptor.Describe(serviceType, implementationType, serviceLifetime)
                );
        }
    }
}

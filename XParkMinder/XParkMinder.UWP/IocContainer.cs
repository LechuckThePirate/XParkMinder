using Autofac;
using XParkMinder.Application.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Application.Impl.ServiceLibrary;
using XParkMinder.AzureMobile.Infrastructure.ServiceLibrary;
using XParkMinder.Geo.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Geo.Impl.ServiceLibrary;
using XParkMinder.UWP.NativeServices;
using XParkMinder.ViewModels;
using XParkMinder.Views;

namespace XParkMinder.UWP
{
    public class IocContainer
    {
        private IContainer _container = null;

        private static IocContainer _instance;
        public static IocContainer Instance => _instance ?? (_instance = new IocContainer());

        public IocContainer()
        {
            var builder = new ContainerBuilder();

            // REGISTER YOUR TYPES HERE
            builder.RegisterType<XParkMinderApp>().AsSelf();

            // Infrastructure 
            builder.RegisterType<ParkMinderDbContext>().AsSelf();

            builder.RegisterType<ParkingService>().As<IParkingService>();
            builder.RegisterType<UwpGpsService>().As<IGpsService>();
            builder.RegisterType<GeoService>().As<IGeoService>();
            
            // ViewModels
            builder.RegisterType<MapViewModel>().AsSelf().InstancePerLifetimeScope();

            // Views
            builder.RegisterType<MapView>().AsSelf();

            _container = builder.Build();
        }

        public static T Resolve<T>()
        {
            return Instance._container.Resolve<T>();
        }

        public static ILifetimeScope BeginLifetimeScope()
        {
            return Instance._container.BeginLifetimeScope();
        }

    }
}
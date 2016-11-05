using Android.Content;
using Autofac;
using XParkMinder.Application.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Application.Impl.ServiceLibrary;
using XParkMinder.AzureMobile.Infrastructure.ServiceLibrary;
using XParkMinder.Domain.Library.Contracts;
using XParkMinder.Droid.NativeServices;
using XParkMinder.Geo.Contracts.ServiceLibrary.Contracts;
using XParkMinder.Geo.Impl.ServiceLibrary;
using XParkMinder.ViewModels;
using XParkMinder.Views;

namespace XParkMinder.Droid
{
    public static class IocContainer
    {
        private static IContainer _container;

        public static IContainer Container => _container ?? (_container = RegisterTypes());

        public static IContainer RegisterTypes()
        {
            var builder = new ContainerBuilder();

            // REGISTER YOUR TYPES HERE
            builder.RegisterType<XParkMinderApp>().AsSelf();

            // Infrastructure 
            builder.RegisterType<ParkMinderDbContext>().AsSelf();

            builder.RegisterType<ParkingService>().As<IParkingService>();
            builder.Register(x => new GpsService(Android.App.Application.Context)).As<IGpsService>();
            builder.RegisterType<GeoService>().As<IGeoService>();
            
            // ViewModels
            builder.RegisterType<MapViewModel>().AsSelf().InstancePerLifetimeScope();

            // Views
            builder.RegisterType<MapView>().AsSelf();

            return builder.Build();
        }

    }
}
using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using GalaSoft.MvvmLight.Ioc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity;
using Unity.Lifetime;
using Unity.RegistrationByConvention;
using Unity.ServiceLocation;
using WPF.DependencyInjection.Common;
using WPF.DependencyInjection.FakeServices;
using WPF.DependencyInjection.IServices;

namespace WPF.DependencyInjection.ViewModels
{
    public class ViewModelLocator
    {

        // private readonly UnityContainer container;
        // private readonly IContainer container;

        private readonly LifetimeManager _mainWindowLifetimeManager = new ContainerControlledLifetimeManager();
        private readonly LifetimeManager _databaseLifetimeManager = new TransientLifetimeManager();

        public ViewModelLocator()
        {
            UseIoc();

            // UseUnity();

            // UseAutoFac();

        }

        private void UseIoc()
        {
            SimpleIoc.Default.Register<ShellViewModel>();
            SimpleIoc.Default.Register<Page1ViewModel>();
            SimpleIoc.Default.Register<CustomersViewModel>();
            SimpleIoc.Default.Register<ICustomersService, CustomersService>();
            SimpleIoc.Default.Register<IFrameNavigationService, FrameNavigationService>();

            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

        }

        private void UseUnity()
        {
            var container = new UnityContainer();
            container.RegisterType<CustomersViewModel>(_mainWindowLifetimeManager);
            container.RegisterType<ICustomersService, CustomersService>();
            container.RegisterSingleton<IFrameNavigationService, FrameNavigationService>();

            // Set the service locator to an UnityServiceLocator.
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

            //container.RegisterTypes(
            //       AllClasses.FromLoadedAssemblies(),
            //       WithMappings.FromMatchingInterface,
            //       WithName.Default);
        }

        private static void UseAutoFac()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<FrameNavigationService>().As<IFrameNavigationService>().SingleInstance();
            builder.RegisterType<CustomersService>().As<ICustomersService>();

            builder.RegisterType<ShellViewModel>();
            builder.RegisterType<Page1ViewModel>();
            builder.RegisterType<CustomersViewModel>();

            // Perform registrations and build the container.
            var container = builder.Build();

            // Set the service locator to an AutofacServiceLocator.
            // PM> Install-Package Autofac.Extras.CommonServiceLocator
            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(container));
        }


        // ServiceLocator jest abstrakcją do wstrzykiwania. 
        // Izoluje nas od konkretnej implementacji DI

        // Wstrzykiwanie pośrednie poprzez ServiceLocator
        public ShellViewModel ShellViewModel => ServiceLocator.Current.GetInstance<ShellViewModel>();
        public CustomersViewModel CustomersViewModel => ServiceLocator.Current.GetInstance<CustomersViewModel>();
        public Page1ViewModel Page1ViewModel => ServiceLocator.Current.GetInstance<Page1ViewModel>();

        // Wstrzykiwanie bezpośrednie za pomocą Unity
        //public ShellViewModel ShellViewModel => container.Resolve<ShellViewModel>();
        //public CustomersViewModel CustomersViewModel => container.Resolve<CustomersViewModel>();
        //public Page1ViewModel Page1ViewModel => container.Resolve<Page1ViewModel>();


        // Wstrzykiwanie bezpośrednie za pomocą AutoFac
        //public ShellViewModel ShellViewModel => container.Resolve<ShellViewModel>();
        //public CustomersViewModel CustomersViewModel => container.Resolve<CustomersViewModel>();
        //public Page1ViewModel Page1ViewModel => container.Resolve<Page1ViewModel>();

    }
}

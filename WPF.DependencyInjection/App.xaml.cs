using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Unity;
using Unity.RegistrationByConvention;
using WPF.DependencyInjection.FakeServices;
using WPF.DependencyInjection.IServices;
using WPF.DependencyInjection.Views;

namespace WPF.DependencyInjection
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        //protected override void OnStartup(StartupEventArgs e)
        //{
        //    IUnityContainer container = new UnityContainer();

        //    container.RegisterType<ICustomersService, CustomersService>();

        //    //container.RegisterTypes(
        //    //   AllClasses.FromLoadedAssemblies(),
        //    //   WithMappings.FromMatchingInterface,
        //    //   WithName.Default);

        //    var view = container.Resolve<CustomersView>();

           

        //    view.Show();
        //}
    }
}

using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using WPF.DependencyInjection.Common;
using WPF.DependencyInjection.Models;

namespace WPF.DependencyInjection.ViewModels
{
    public class Page1ViewModel : ViewModelBase
    {
        private readonly IFrameNavigationService navigationService;

        public Customer Customer { get; set; }

        public Page1ViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;

            Customer = navigationService.Parameter as Customer;
        }

        private ICommand _ShowCustomersCommand;

        public ICommand ShowCustomersCommand => _ShowCustomersCommand ?? (_ShowCustomersCommand = new RelayCommand(() => navigationService.Navigate("Customers")));
    }
}

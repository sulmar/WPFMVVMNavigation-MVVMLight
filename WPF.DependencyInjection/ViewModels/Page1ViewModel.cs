using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;
using WPF.DependencyInjection.Common;
using WPF.DependencyInjection.Models;

namespace WPF.DependencyInjection.ViewModels
{
    public class Page1ViewModel : ViewModelBase
    {
        private readonly INavigationService navigationService;

        public Customer Customer { get; set; }

        public Page1ViewModel(INavigationService navigationService)
        {
            this.navigationService = navigationService;
            
        }

        private ICommand _ShowCustomersCommand;

        public ICommand ShowCustomersCommand => _ShowCustomersCommand ?? (_ShowCustomersCommand = new RelayCommand(() => navigationService.NavigateTo("Customers")));
    }
}

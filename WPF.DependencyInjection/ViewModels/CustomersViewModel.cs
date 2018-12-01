using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Windows.Input;
using WPF.DependencyInjection.Common;
using WPF.DependencyInjection.IServices;
using WPF.DependencyInjection.Models;

namespace WPF.DependencyInjection.ViewModels
{
    public class CustomersViewModel : ViewModelBase
    {
        private readonly ICustomersService customersService;
        private readonly INavigationService navigationService;

        public Customer SelectedCustomer { get; set; }

        public CustomersViewModel(INavigationService navigationService, ICustomersService customersService)
        {
            this.navigationService = navigationService;
            this.customersService = customersService;

        }

        private ICommand _loadedCommand;

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(Load));

        private void Load()
        {
            Customers = customersService.Get();
        }

        
        private IList<Customer> _customers;

        public IList<Customer> Customers
        {
            get { return _customers; }
            set { _customers = value;
                RaisePropertyChanged();

            }
        }

        private ICommand _ShowPage1Command;

        public ICommand ShowPage1Command => _ShowPage1Command ?? (_ShowPage1Command = new RelayCommand(() => navigationService.NavigateTo("Page1", SelectedCustomer)));
    }
}

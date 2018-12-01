using GalaSoft.MvvmLight.Command;
using System.Windows.Input;
using WPF.DependencyInjection.Common;

namespace WPF.DependencyInjection.ViewModels
{
    public class ShellViewModel : ViewModelBase
    {
        private readonly IFrameNavigationService navigationService;

        public ShellViewModel(IFrameNavigationService navigationService)
        {
            this.navigationService = navigationService;
        }

        private ICommand _loadedCommand;

        public ICommand LoadedCommand => _loadedCommand ?? (_loadedCommand = new RelayCommand(() => navigationService.Navigate("Page1", "Hello World")));
    }
}

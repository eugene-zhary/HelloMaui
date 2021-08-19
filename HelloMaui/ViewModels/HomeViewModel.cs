using HelloMaui.Services.Navigation;
using HelloMaui.Services.Repository;
using HelloMaui.Views;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace HelloMaui.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IRepositoryService _repositoryService;

        public HomeViewModel(
            INavigationService navigationService,
            IRepositoryService repositoryService)
            : base(navigationService)
        {
            _repositoryService = repositoryService;

            Title = "Home";
        }

        #region -- Public properties --

        private ICommand _navigateCommand;
        public ICommand NavigateCommand => _navigateCommand ??= new Command(OnNavigate);

        #endregion

        #region -- Private helpers --

        private async void OnNavigate(object obj)
        {
            await NavigationService.NavigateAsync(typeof(LoginPage));
        }

        #endregion
    }
}
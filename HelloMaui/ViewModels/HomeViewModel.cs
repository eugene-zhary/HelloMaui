using HelloMaui.Services.Navigation;
using HelloMaui.Services.Repository;
using HelloMaui.Pages;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using HelloMaui.Services.PageDialog;
using HelloMaui.Resources;
using HelloMaui.Models;

namespace HelloMaui.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        private readonly IRepositoryService _repositoryService;

        public HomeViewModel(
            INavigationService navigationService,
            IPageDialogService pageDialogService,
            IRepositoryService repositoryService)
            : base(navigationService, pageDialogService)
        {
            _repositoryService = repositoryService;

            Title = Strings.HomeTitle;
        }

        #region -- Public properties --

        private UserModel _user;
        public UserModel User
        {
            get => _user;
            set => SetProperty(ref _user, value, nameof(User));
        }

        #endregion

        #region -- Overrides --

        public override void OnNavigatedTo(INavigationParameters parameter)
        {
            base.OnNavigatedTo(parameter);

            if (parameter.TryGetValue(Constants.Navigation.USER, out UserModel navUser))
            {
                User = navUser;
            }
        }

        #endregion

        #region -- Private helpers --


        #endregion
    }
}
using HelloMaui.Helpers;
using HelloMaui.Pages;
using HelloMaui.Resources;
using HelloMaui.Services.Authorization;
using HelloMaui.Services.Navigation;
using HelloMaui.Services.PageDialog;
using System.Windows.Input;

namespace HelloMaui.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IAuthorizationService _authorizationService;

        public LoginViewModel(
            INavigationService navigationService,
            IPageDialogService pageDialogService,
            IAuthorizationService authorizationService)
            : base(navigationService, pageDialogService)
        {
            _authorizationService = authorizationService;
            _email = string.Empty;
            _password = string.Empty;

            Title = Strings.LoginTitle;
        }

        #region -- Public properties --

        private string _email;
        public string Email
        {
            get => _email;
            set => SetProperty(ref _email, value, nameof(Email));
        }

        private string _password;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value, nameof(Password));
        }

        private ICommand _loginCommand;
        public ICommand LoginCommand => _loginCommand ??= SingleExecutionCommand.FromFunc(OnLoginAsync);

        private ICommand _registerCommand;
        public ICommand RegisterCommand => _registerCommand ??= SingleExecutionCommand.FromFunc(OnRegisterAsync);

        #endregion

        #region -- Private helpers --

        private async Task OnLoginAsync()
        {
            if (IsFieldsValid)
            {
                await AuthUserAsync();
            }
            else
            {
                await PageDialogService.DisplayAlertAsync(Title, Strings.BadFormat, Strings.Cancel);
            }
        }

        private Task OnRegisterAsync()
        {
            return NavigationService.NavigateAsync(typeof(RegisterPage));
        }

        private async Task AuthUserAsync()
        {
            var user = await _authorizationService.GetUserViaEmailAsync(_email);

            if (user != null)
            {
                if (user.Password.Equals(_password))
                {
                    NavigationParameters navParams = new();
                    navParams.Add(Constants.Navigation.USER, user);

                    await NavigationService.NavigateAsync(typeof(HomePage), navParams);
                }
                else
                {
                    await PageDialogService.DisplayAlertAsync(Title, Strings.InvalidPass, Strings.Cancel);
                }
            }
            else
            {
                await PageDialogService.DisplayAlertAsync(Title, Strings.NoUser, Strings.Cancel);
            }
        }

        private bool IsFieldsValid => !(string.IsNullOrWhiteSpace(_email)
            || string.IsNullOrWhiteSpace(_password));


        #endregion
    }
}

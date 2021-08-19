using HelloMaui.Helpers;
using HelloMaui.Pages;
using HelloMaui.Resources;
using HelloMaui.Services.Authorization;
using HelloMaui.Services.Navigation;
using HelloMaui.Services.PageDialog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HelloMaui.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        private readonly IAuthorizationService _authorizationService;

        public RegisterViewModel(
            INavigationService navigationService,
            IPageDialogService pageDialogService,
            IAuthorizationService authorizationService)
            : base(navigationService, pageDialogService)
        {
            _authorizationService = authorizationService;

            _name = string.Empty;
            _email = string.Empty;
            _password = string.Empty;

            Title = Strings.RegisterTitle;
        }

        #region -- Public properties --

        private string _name;
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value, nameof(Name));
        }

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

        private ICommand _createCommand;
        public ICommand CreateCommand => _createCommand ??= SingleExecutionCommand.FromFunc(OnCreateAsync);

        #endregion

        #region -- Private helpers --

        private async Task OnCreateAsync()
        {
            if (IsFieldsValid)
            {
                await RegisterUserAsync();
            }
            else
            {
                await PageDialogService.DisplayAlertAsync(Title, Strings.BadFormat, Strings.Cancel);
            }
        }

        private async Task RegisterUserAsync()
        {
            var user = await _authorizationService.GetUserViaEmailAsync(_email);

            if (user == null)
            {
                user = new()
                {
                    Name = _name,
                    Email = _email,
                    Password = _password
                };

                await _authorizationService.AddUserAsync(user);

                await PageDialogService.DisplayAlertAsync(Title, Strings.RegisterSucced, Strings.Cancel);

                await NavigationService.GoBackAsync();
            }
            else
            {
                await PageDialogService.DisplayAlertAsync(Title, Strings.CreateFailed, Strings.Cancel);
            }
        }

        private bool IsFieldsValid => !(string.IsNullOrWhiteSpace(_name)
            || string.IsNullOrWhiteSpace(_email)
            || string.IsNullOrWhiteSpace(_password));


        #endregion
    }
}

using HelloMaui.Services.Navigation;

namespace HelloMaui.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        public LoginViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Login Page";
        }

        #region -- Public properties --

        private string _text;
        public string Text
        {
            get => _text;
            set => SetProperty(ref _text, value, nameof(Text));
        }

        #endregion

        #region -- Overrides --

        public override void OnNavigatedTo(INavigationParameters parameter)
        {
            if (parameter.TryGetValue(Constants.Navigation.LOGIN, out string text))
            {
                Text = text;
            }
        }

        #endregion
    }
}

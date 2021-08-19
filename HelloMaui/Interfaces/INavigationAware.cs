using HelloMaui.Services.Navigation;

namespace HelloMaui.Interfaces
{
    public interface INavigationAware
    {
        void OnNavigatedTo(INavigationParameters parameter);
    }
}

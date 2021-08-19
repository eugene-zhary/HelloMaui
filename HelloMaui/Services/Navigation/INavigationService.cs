namespace HelloMaui.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateAsync(Type pageType, object parameter = null);
        Task GoBackAsync();
    }
}

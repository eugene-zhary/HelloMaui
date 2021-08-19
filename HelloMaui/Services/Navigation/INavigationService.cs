namespace HelloMaui.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateAsync(Type pageType, INavigationParameters navigationParameters = null);
        Task GoBackAsync();
    }
}

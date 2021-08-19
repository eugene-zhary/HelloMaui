namespace HelloMaui.Services.Navigation
{
    public interface INavigationParameters
    {
        void Add(string key, object value);

        bool TryGetValue<T>(string key, out T value);
    }
}

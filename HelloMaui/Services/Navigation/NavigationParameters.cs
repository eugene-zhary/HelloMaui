namespace HelloMaui.Services.Navigation
{
    public class NavigationParameters : INavigationParameters
    {
        private readonly Dictionary<string, object> _parameters = new Dictionary<string, object>();

        public void Add(string key, object value) =>
            _parameters.Add(key, value);

        public bool TryGetValue<T>(string key, out T value)
        {
            bool isContain = _parameters.ContainsKey(key);

            value = isContain ? (T)_parameters[key] : default;

            return isContain;
        }
    }
}
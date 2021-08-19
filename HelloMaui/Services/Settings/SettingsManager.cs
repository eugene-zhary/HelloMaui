using Microsoft.Maui.Essentials;

namespace HelloMaui.Services.Settings
{
    public class SettingsManager : ISettingsManager
    {
        public int UserId
        {
            get => Preferences.Get(nameof(UserId), 0);
            set => Preferences.Set(nameof(UserId), value);
        }
    }
}

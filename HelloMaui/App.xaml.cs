using HelloMaui.Views;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.PlatformConfiguration.WindowsSpecific;
using Application = Microsoft.Maui.Controls.Application;

namespace HelloMaui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var page = Resolver.Resolve<HomePage>() as ContentPage;

            MainPage = new NavigationPage(page);
        }
    }
}

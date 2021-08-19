using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using Microsoft.Maui.Controls.Hosting;
using Autofac;
using HelloMaui.Services.Repository;
using HelloMaui.ViewModels;
using HelloMaui.Pages;
using HelloMaui.Services.Navigation;

namespace HelloMaui
{
    public class Startup : IStartup
    {
        public void Configure(IAppHostBuilder appBuilder)
        {
            appBuilder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            RegisterTypes();
        }

        public void RegisterTypes()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<NavigationService>().As<INavigationService>();
            containerBuilder.RegisterType<RepositoryService>().As<IRepositoryService>();

            containerBuilder.RegisterType<LoginViewModel>();
            containerBuilder.RegisterType<RegisterViewModel>();
            containerBuilder.RegisterType<HomeViewModel>();

            containerBuilder.RegisterType<LoginPage>();
            containerBuilder.RegisterType<RegisterPage>();
            containerBuilder.RegisterType<HomePage>();

            var container = containerBuilder.Build();
            Resolver.Initialize(container);
        }
    }
}
using HelloMaui.Interfaces;
using HelloMaui.Services.Navigation;
using Microsoft.Maui.Controls;

namespace HelloMaui.Pages
{
    public abstract class BaseContentPage : ContentPage
    {
        public void SendParameter(INavigationParameters navigationParameters)
        {
            if (BindingContext is INavigationAware navigationAware)
            {
                if (navigationParameters is null)
                {
                    navigationParameters = new NavigationParameters();
                }

                navigationAware.OnNavigatedTo(navigationParameters);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (BindingContext is IViewActionsHandler viewActionsHandler)
            {
                viewActionsHandler.OnAppearing();
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();

            if (BindingContext is IViewActionsHandler viewActionsHandler)
            {
                viewActionsHandler.OnDisappearing();
            }
        }
    }
}

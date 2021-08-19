using HelloMaui.Interfaces;
using Microsoft.Maui.Controls;

namespace HelloMaui.Pages
{
    public abstract class BaseContentPage : ContentPage
    {
        public void SendParameter(object parameter)
        {
            if (BindingContext is INavigationAware navigationAware)
            {
                navigationAware.OnNavigatedTo(parameter);
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

using System;
using HelloMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace HelloMaui.Views
{
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = Resolver.Resolve<LoginViewModel>();
        }
    }
}

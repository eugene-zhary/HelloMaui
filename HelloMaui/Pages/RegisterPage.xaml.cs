using System;
using HelloMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace HelloMaui.Views
{
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

            BindingContext = Resolver.Resolve<RegisterViewModel>();
        }
    }
}

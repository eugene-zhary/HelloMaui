using System;
using HelloMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace HelloMaui.Pages
{
    public partial class LoginPage : BaseContentPage
    {
        public LoginPage()
        {
            InitializeComponent();

            BindingContext = Resolver.Resolve<LoginViewModel>();
        }
    }
}

using System;
using HelloMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace HelloMaui.Pages
{
    public partial class RegisterPage : BaseContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();

            BindingContext = Resolver.Resolve<RegisterViewModel>();
        }
    }
}

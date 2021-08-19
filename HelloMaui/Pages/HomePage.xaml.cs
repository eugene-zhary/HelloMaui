using System;
using HelloMaui.ViewModels;
using Microsoft.Maui.Controls;

namespace HelloMaui.Pages
{
    public partial class HomePage : BaseContentPage
    {
        public HomePage()
        {
            InitializeComponent();

            BindingContext = Resolver.Resolve<HomeViewModel>();
        }
    }
}
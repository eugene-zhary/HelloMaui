using HelloMaui.Services.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMaui.ViewModels
{
    public class RegisterViewModel : BaseViewModel
    {
        public RegisterViewModel(INavigationService navigationService) : base(navigationService)
        {
            Title = "Register Page";
        }
    }
}

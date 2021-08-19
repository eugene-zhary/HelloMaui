using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMaui.Services.Navigation
{
    public interface INavigationService
    {
        Task NavigateAsync(Type pageType);
        Task GoBackAsync();
    }
}

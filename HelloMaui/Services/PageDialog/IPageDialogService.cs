using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloMaui.Services.PageDialog
{
    public interface IPageDialogService
    {
        public Task DisplayAlertAsync(string title, string message, string cancelButton);
    }
}

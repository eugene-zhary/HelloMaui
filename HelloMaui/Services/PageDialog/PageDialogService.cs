using Microsoft.Maui.Controls;

namespace HelloMaui.Services.PageDialog
{
    public class PageDialogService : IPageDialogService
    {
        #region -- Public properties --

        private Page _currentPage;
        protected Page CurrentPage => _currentPage ??= App.Current.MainPage;

        #endregion

        #region -- IPageDialogService implementation --

        public Task DisplayAlertAsync(string title, string message, string cancel)
        {
            return CurrentPage.DisplayAlert(title, message, cancel);
        }

        #endregion
    }
}

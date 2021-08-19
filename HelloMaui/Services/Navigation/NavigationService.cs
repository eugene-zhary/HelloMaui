﻿using Microsoft.Maui.Controls;

namespace HelloMaui.Services.Navigation
{
    public class NavigationService : INavigationService
    {
        #region -- Public properties --

        private Page _currentPage;
        protected Page CurrentPage => _currentPage ??= App.Current.MainPage;

        #endregion

        #region -- INavigationService implementation --

        public Task GoBackAsync()
        {
            return CurrentPage.Navigation.PopAsync();
        }

        public Task NavigateAsync(Type pageType)
        {
            Page target = Activator.CreateInstance(pageType) as Page;

            return CurrentPage.Navigation.PushAsync(target);
        }

        #endregion
    }
}

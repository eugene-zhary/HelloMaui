using HelloMaui.Interfaces;
using HelloMaui.Services.Navigation;
using HelloMaui.Services.PageDialog;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace HelloMaui.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged, INavigationAware
    {
        public BaseViewModel(
            INavigationService navigationService,
            IPageDialogService pageDialogService)
        {
            NavigationService = navigationService;
            PageDialogService = pageDialogService;
        }

        #region -- Public properties --

        protected INavigationService NavigationService { get; }
        protected IPageDialogService PageDialogService { get; }

        private string _title;
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value, nameof(Title));
        }

        #endregion

        #region -- Public helpers --

        protected virtual bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            bool result = false;

            if (!EqualityComparer<T>.Default.Equals(storage, value))
            {
                storage = value;
                RaisePropertyChanged(propertyName);

                result = true;
            }

            return result;
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            OnPropertyChanged(new PropertyChangedEventArgs(propertyName));
        }

        protected virtual void OnPropertyChanged(PropertyChangedEventArgs args)
        {
            PropertyChanged?.Invoke(this, args);
        }

        #endregion

        #region -- INotifyPropertyChanged implementation --

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion 

        #region -- INavigationAware implementation --

        public virtual void OnNavigatedTo(INavigationParameters parameter) { }

        #endregion
    }
}
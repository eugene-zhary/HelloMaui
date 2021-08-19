using HelloMaui.Models;

namespace HelloMaui.Stores
{
    public class UserStore : BaseStore
    {
        private UserModel _currentUser = new();
        public UserModel CurrentUser
        {
            get => _currentUser;
            set => SetCurrentItem(ref _currentUser, value);
        }
    }
}

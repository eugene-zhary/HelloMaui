using HelloMaui.Models;

namespace HelloMaui.Services.Authorization
{
    public interface IAuthorizationService
    {
        bool IsAuthorized { get; }

        Task<UserModel> GetUserViaEmailAsync(string email);

        Task<bool> AddUserAsync(UserModel user);

        void SetCurrentUserId(int userId);
    }
}

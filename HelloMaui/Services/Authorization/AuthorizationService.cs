using HelloMaui.Models;
using HelloMaui.Services.Repository;
using HelloMaui.Services.Settings;

namespace HelloMaui.Services.Authorization
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly IRepositoryService _repositoryService;
        private readonly ISettingsManager _settingsManager;
        public AuthorizationService(
            IRepositoryService repositoryService,
            ISettingsManager settingsManager)
        {
            _repositoryService = repositoryService;
            _settingsManager = settingsManager;
        }

        #region -- IAuthorizationService implementation --

        public bool IsAuthorized => _settingsManager.UserId > 0;

        public async Task<UserModel> GetUserViaEmailAsync(string email)
        {
            UserModel user = new();

            try
            {
                user = await _repositoryService.FirstOrDefaultAsync<UserModel>(x => x.Email.Equals(email));
            }
            catch
            {
                throw;
            }

            return user;
        }

        public async Task<bool> AddUserAsync(UserModel user)
        {
            bool isUnique = false;

            try
            {
                isUnique = await CheckUserUniquenessViaEmailAsync(user.Email);

                if (isUnique)
                {
                    await _repositoryService.AddAsync(user);
                }
            }
            catch
            {
                throw;
            }

            return isUnique;
        }

        public void SetCurrentUserId(int userId)
        {
            _settingsManager.UserId = userId;
        }

        #endregion

        #region -- Private helpers --

        private async Task<bool> CheckUserUniquenessViaEmailAsync(string email)
        {
            bool result = false;

            try
            {
                var user = await _repositoryService.FirstOrDefaultAsync<UserModel>(x => x.Email.Equals(email));

                result = user == null;
            }
            catch
            {
                throw;
            }

            return result;
        }


        #endregion
    }
}

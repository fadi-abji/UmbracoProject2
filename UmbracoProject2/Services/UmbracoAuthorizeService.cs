using Wengine.Base;
using Wengine.Business.Services;
using Wengine.Core.Identity.Models;
using Wengine.Core.Settings;
using Wengine.DTO;

namespace UmbracoProject2.Services
{
    public class UmbracoAuthorizeService : IAuthorizeService
    {
        public Task<WxrResponse<UserInfo>> GetUserInfo()
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<WengineUserLookup>> GetWengineUser()
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<JwtResponse>> JwtLogin(JwtLogin loginModel)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> Login(LoginModel loginParameters)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> Logout()
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> PasswordReset(string email)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> Register(RegisterUserModel parameters)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse<Wengine.DAL.WengineUser>> RegisterUserFromEntraId(string email, string languageCode)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> UpdatePassword(ResetPasswordModel registerParameters)
        {
            throw new NotImplementedException();
        }

        public Task<WxrResponse> ValidateUpdateUserPasswordToken(Guid guid)
        {
            throw new NotImplementedException();
        }
    }
}

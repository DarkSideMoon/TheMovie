using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheMovie.Model.Security;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Auth
{
    public class AuthService : IAuthService
    {
        public Task<GuestSession> CreateGuestSessionAsync()
        {
            throw new NotImplementedException();
        }

        public Task<string> CreateTokenAsync()
        {
            throw new NotImplementedException();
        }

        public Task<UserSession> CreateUserSessionAsync(AuthViewModel authViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteUserSessionAsync(AuthViewModel authViewModel)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsGetPermissionSuccessAsync(AuthViewModel authViewModel)
        {
            throw new NotImplementedException();
        }
    }
}

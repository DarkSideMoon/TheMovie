﻿using System.Threading.Tasks;
using TheMovie.Model.Security;
using TheMovie.Service.ViewModel;

namespace TheMovie.Service.Service.Auth
{
    public interface IAuthService
    {
        /// <summary>
        /// Create async token to get permission of application
        /// </summary>
        /// <returns></returns>
        Task<Token> CreateTokenAsync();

        /// <summary>
        /// Delete async user session
        /// </summary>
        /// <param name="requestToken">Token</param>
        /// <returns></returns>
        Task<bool> DeleteUserSessionAsync(SessionViewModel sessionViewModel);

        /// <summary>
        /// Create user session async
        /// </summary>
        /// <param name="requestToken">Token</param>
        /// <returns></returns>
        Task<UserSession> CreateUserSessionAsync(AuthViewModel authViewModel);

        /// <summary>
        /// Create guest session async
        /// </summary>
        /// <returns></returns>
        Task<GuestSession> CreateGuestSessionAsync();
    }
}

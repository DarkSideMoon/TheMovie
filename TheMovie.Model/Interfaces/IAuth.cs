using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using TheMovie.Model.Security;

namespace TheMovie.Model.Interfaces
{
    public interface IAuth
    {
        /// <summary>
        /// Create token to get permission of application
        /// </summary>
        /// <returns></returns>
        string CreateToken();

        /// <summary>
        /// Create async token to get permission of application
        /// </summary>
        /// <returns></returns>
        Task<string> CreateTokenAsync();

        /// <summary>
        /// Check is success of getting permission
        /// </summary>
        /// <param name="requestToken">Token</param>
        /// <returns></returns>
        bool IsGetPermissionSuccess(string requestToken);

        /// <summary>
        /// Delete user session
        /// </summary>
        /// <param name="requestToken">Token</param>
        /// <returns></returns>
        bool DeleteUserSession(string requestToken);

        /// <summary>
        /// Delete async user session
        /// </summary>
        /// <param name="requestToken">Token</param>
        /// <returns></returns>
        Task<bool> DeleteUserSessionAsync(string requestToken);

        /// <summary>
        /// Check async is success of getting permission
        /// </summary>
        /// <param name="requestToken">Token</param>
        /// <returns></returns>
        Task<bool> IsGetPermissionSuccessAsync(string requestToken);

        /// <summary>
        /// Create user session
        /// </summary>
        /// <param name="requestToken">Token</param>
        /// <returns></returns>
        UserSession CreateUserSession(string requestToken);

        /// <summary>
        /// Create user session async
        /// </summary>
        /// <param name="requestToken">Token</param>
        /// <returns></returns>
        Task<UserSession> CreateUserSessionAsync(string requestToken);

        /// <summary>
        /// Create guest session
        /// </summary>
        /// <returns></returns>
        GuestSession CreateGuestSession();

        /// <summary>
        /// Create guest session async
        /// </summary>
        /// <returns></returns>
        Task<GuestSession> CreateGuestSessionAsync();


    }
}

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using RestSharp;
using TheMovie.Model.Security;

namespace TheMovie.Model.Interfaces
{
    public interface IAuth
    {
        /// <summary>
        /// Creare token to get permission of application
        /// </summary>
        /// <returns></returns>
        string CreateToken();

        /// <summary>
        /// Check is success of getting permission
        /// </summary>
        /// <param name="requestToken">Token</param>
        /// <returns></returns>
        bool IsGetPermissionSuccess(string requestToken);

        /// <summary>
        /// Create user session
        /// </summary>
        /// <param name="requestToken">Token</param>
        /// <returns></returns>
        IRestResponse<UserSession> CreateUserSession(string requestToken);

        /// <summary>
        /// Create guest session
        /// </summary>
        /// <returns></returns>
        IRestResponse<GuestSession> CreateGuestSession();
    }
}

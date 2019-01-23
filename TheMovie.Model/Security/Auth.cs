using System;
using System.Collections.Generic;
using System.Text;
using RestSharp;
using TheMovie.Model.Interfaces;

namespace TheMovie.Model.Security
{
    public class Auth : IAuth
    {
        public string CreateToken()
        {
            throw new NotImplementedException();
        }

        public bool IsGetPermissionSuccess(string requestToken)
        {
            throw new NotImplementedException();
        }

        public IRestResponse<UserSession> CreateUserSession(string requestToken)
        {
            throw new NotImplementedException();
        }

        public IRestResponse<GuestSession> CreateGuestSession()
        {
            throw new NotImplementedException();
        }
    }
}

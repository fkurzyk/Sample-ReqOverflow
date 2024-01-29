using System;
using System.Net;
using ReqOverflow.Specs.Controller.Support;
using ReqOverflow.Web.Controllers;
using ReqOverflow.Web.Models;
using ReqOverflow.Web.Utils;

namespace ReqOverflow.Specs.Controller.Drivers
{
    public class AuthDriver
    {
        private readonly AuthContext _authContext;
        
        public LoginDriver Login { get; }

        public AuthDriver(LoginDriver login, AuthContext authContext)
        {
            Login = login;
            _authContext = authContext;
        }

        public UserReferenceModel GetCurrentUser()
        {
            var controller = new AuthController();
            try
            {
                return controller.GetCurrentUser(_authContext.AuthToken);
            }
            catch (HttpResponseException e) when (e.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }
        }
    }
}

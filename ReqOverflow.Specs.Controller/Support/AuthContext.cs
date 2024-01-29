using System;
using ReqOverflow.Specs.Controller.Drivers;
using ReqOverflow.Web.Models;

namespace ReqOverflow.Specs.Controller.Support
{
    public class AuthContext
    {
        private readonly LoginDriver _loginDriver;

        public string AuthToken { get; set; }
        public string LoggedInUserName { get; set; }

        public bool IsLoggedIn => LoggedInUserName != null;

        public AuthContext(LoginDriver loginDriver)
        {
            _loginDriver = loginDriver;

            loginDriver.OnAuthenticated += (loginInput, authToken) =>
            {
                AuthToken = authToken;
                LoggedInUserName = loginInput.Name;
            };
        }

        public void Authenticate(string userName, string password)
        {
            _loginDriver.Perform(new LoginInputModel{Name = userName, Password = password});
        }
    }
}
